using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XtermBlazor
{
    /// <summary>
    /// Xterm Element
    /// </summary>
    public partial class Xterm : ComponentBase, IAsyncDisposable
    {
        private const string NAMESPACE_PREFIX = nameof(XtermBlazor);

        private readonly Dictionary<string, XtermAddon> _xtermAddons = [];

        [Inject]
        internal IJSRuntime JSRuntime { get; set; } = default!;

        /// <summary>
        /// Terminal id. This defaults to ElementReference.Id.
        /// </summary>
        [Parameter]
        public string Id { get; set; } = string.Empty;

        /// <summary>
        /// Represents a reference to a rendered element.
        /// </summary>
        public ElementReference ElementReference { get; set; }

        /// <summary>
        /// Determine whether the terminal is registered and rendered.
        /// </summary>
        public bool IsRendered { get; private set; }

        /// <summary>
        /// An object containing a set of options.
        /// </summary>
        [Parameter]
        public TerminalOptions Options { get; set; } = new();

        /// <summary>
        /// A HashSet containing addons that will be loaded and used.
        /// </summary>
        [Parameter]
        public HashSet<string> Addons { get; set; } = [];

        /// <summary>
        /// User class names, separated by space.
        /// </summary>
        [Parameter]
        public string Class { get; set; } = string.Empty;

        /// <summary>
        /// User styles, applied on top of the component's own classes and styles.
        /// </summary>
        [Parameter]
        public string Style { get; set; } = string.Empty;

        #region EventCallbacks
        /// <summary>
        /// Adds an event listener for when first rendered.
        /// </summary>
        [Parameter]
        public EventCallback OnFirstRender { get; set; }

        /// <summary>
        /// Adds an event listener for when a binary event fires. This is used to
        /// enable non UTF-8 conformant binary messages to be sent to the backend.
        /// Currently this is only used for a certain type of mouse reports that
        /// happen to be not UTF-8 compatible.
        /// The event value is a JS string, pass it to the underlying pty as
        /// binary data, e.g. `pty.write(Buffer.from(data, 'binary'))`.
        /// </summary>
        [Parameter]
        public EventCallback<string> OnBinary { get; set; }

        /// <summary>
        /// Adds an event listener for the cursor moves.
        /// </summary>
        [Parameter]
        public EventCallback OnCursorMove { get; set; }

        /// <summary>
        /// Adds an event listener for when a data event fires. This happens for
        /// example when the user types or pastes into the terminal. The event value
        /// is whatever `string` results, in a typical setup, this should be passed
        /// on to the backing pty.
        /// </summary>
        [Parameter]
        public EventCallback<string> OnData { get; set; }

        /// <summary>
        /// Adds an event listener for when a key is pressed. The event value contains the
        /// string that will be sent in the data event as well as the DOM event that
        /// triggered it.
        /// </summary>
        [Parameter]
        public EventCallback<KeyEventArgs> OnKey { get; set; }

        /// <summary>
        /// Adds an event listener for when a line feed is added.
        /// </summary>
        [Parameter]
        public EventCallback OnLineFeed { get; set; }

        /// <summary>
        /// Adds an event listener for when a scroll occurs. The event value is the new position of the viewport.
        /// </summary>
        [Parameter]
        public EventCallback<int> OnScroll { get; set; }

        /// <summary>
        /// Adds an event listener for when a selection change occurs.
        /// </summary>
        [Parameter]
        public EventCallback OnSelectionChange { get; set; }

        /// <summary>
        /// Adds an event listener for when rows are rendered. The event value
        /// contains the start row and end rows of the rendered area(ranges from `0`
        /// to `Terminal.rows - 1`).
        /// </summary>
        [Parameter]
        public EventCallback<RenderEventArgs> OnRender { get; set; }

        /// <summary>
        /// Adds an event listener for when the terminal is resized. The event value
        /// contains the new size.
        /// </summary>
        [Parameter]
        public EventCallback<ResizeEventArgs> OnResize { get; set; }

        /// <summary>
        /// Adds an event listener for when an OSC 0 or OSC 2 title change occurs.
        /// The event value is the new title.
        /// </summary>
        [Parameter]
        public EventCallback<string> OnTitleChange { get; set; }

        /// <summary>
        /// Adds an event listener for when the bell is triggered.
        /// </summary>
        [Parameter]
        public EventCallback OnBell { get; set; }
        #endregion

        /// <summary>
        /// The custom KeyboardEvent handler to attach.
        /// This is a function that takes a KeyboardEvent,
        /// allowing consumers to stop propagation and/or prevent the default action.
        /// The function returns whether the event should be processed by xterm.js.
        /// </summary>
        public Func<KeyboardEventArgs, bool> CustomKeyEventHandler { get; private set; } = (_) => true;

        /// <summary>
        /// The custom WheelEvent handler to attach.
        /// This is a function that takes a WheelEvent,
        /// allowing consumers to stop propagation and/or prevent the default action.
        /// The function returns whether the event should be processed by xterm.js.
        /// </summary>
        public Func<WheelEventArgs, bool> CustomWheelEventHandler { get; private set; } = (_) => true;

        /// <inheritdoc />
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                // Assign ElementReference.Id to Id if the original Id is null or empty
                Id = string.IsNullOrEmpty(Id) ? ElementReference.Id : Id;

                // The ElementReference is only used in OnAfterRenderAsync and not in any earlier lifecycle method because there's no JavaScript element until after the component is rendered.
                // https://docs.microsoft.com/en-us/aspnet/core/blazor/components/lifecycle?view=aspnetcore-6.0
                XtermHandler.RegisterTerminal(this);

                // Activate the addons
                foreach (string addonId in Addons)
                {
                    _xtermAddons.Add(addonId, new XtermAddon(this, addonId));
                }

                await JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.registerTerminal", Id, ElementReference, Options, Addons);

                IsRendered = true;

                await OnFirstRender.InvokeAsync();
            }
        }

        /// <summary>
        /// The number of rows in the terminal's viewport.
        /// </summary>
        /// <returns></returns>
        public ValueTask<int> GetRows()
        {
            return JSRuntime.InvokeAsync<int>($"{NAMESPACE_PREFIX}.getRows", Id);
        }

        /// <summary>
        /// The number of columns in the terminal's viewport.
        /// </summary>
        /// <returns></returns>
        public ValueTask<int> GetColumns()
        {
            return JSRuntime.InvokeAsync<int>($"{NAMESPACE_PREFIX}.getCols", Id);
        }

        /// <summary>
        /// Attaches a custom key event handler which is run before keys are
        /// processed, giving consumers of xterm.js ultimate control as to what keys
        /// should be processed by the terminal and what keys should not.
        /// </summary>
        /// <remarks>
        /// Note: The return boolean of <c>customKeyEventHandler</c> is ignored on Blazor Server.
        /// If you wish to pass the return value to xterm.js,
        /// please use <see cref="SetCustomKeyEventHandler"/> instead.
        /// </remarks>
        /// <param name="customKeyEventHandler">
        /// The custom KeyboardEvent handler to attach.
        /// This is a function that takes a KeyboardEvent, allowing consumers to stop
        /// propagation and/or prevent the default action. The function returns
        /// whether the event should be processed by xterm.js.
        /// </param>
        public void AttachCustomKeyEventHandler(Func<KeyboardEventArgs, bool> customKeyEventHandler)
        {
            CustomKeyEventHandler = customKeyEventHandler;
        }

        /// <summary>
        /// Sets a custom key event handler which is run before keys are
        /// processed, giving consumers of xterm.js ultimate control as to what keys
        /// should be processed by the terminal and what keys should not.
        /// </summary>
        /// <remarks>
        /// Note: If your project is using Blazor WebAssembly, you can use <see cref="AttachCustomKeyEventHandler"/> instead.
        /// </remarks>
        /// <param name="customKeyEventHandler">
        /// The custom KeyboardEvent handler to attach.
        /// This is a function that takes a KeyboardEvent, allowing consumers to stop
        /// propagation and/or prevent the default action. The function returns
        /// whether the event should be processed by xterm.js.
        /// </param>
        /// <returns></returns>
        public ValueTask SetCustomKeyEventHandler(string customKeyEventHandler = "function (event) { return true; }")
        {
            return JSRuntime.InvokeVoidAsync("eval", $"{NAMESPACE_PREFIX}.getTerminalObjectById('{Id}').customKeyEventHandler = {customKeyEventHandler}");
        }

        /// <summary>
        /// Attaches a custom wheel event handler which is run before keys are
        /// processed, giving consumers of xterm.js control over whether to proceed
        /// or cancel terminal wheel events.
        /// </summary>
        /// <remarks>
        /// Note: The return boolean of <c>customKeyEventHandler</c> is ignored on Blazor Server.
        /// If you wish to pass the return value to xterm.js,
        /// please use <see cref="SetCustomWheelEventHandler"/> instead.
        /// </remarks>
        /// <param name="customWheelEventHandler">The custom WheelEvent handler to attach.
        /// This is a function that takes a WheelEvent, allowing consumers to stop
        /// propagation and/or prevent the default action. The function returns
        /// whether the event should be processed by xterm.js.</param>
        public void AttachCustomWheelEventHandler(Func<WheelEventArgs, bool> customWheelEventHandler)
        {
            CustomWheelEventHandler = customWheelEventHandler;
        }

        /// <summary>
        /// Sets a custom wheels event handler which is run before keys are
        /// processed, giving consumers of xterm.js control over whether to proceed
        /// or cancel terminal wheel events.
        /// </summary>
        /// <remarks>
        /// Note: If your project is using Blazor WebAssembly, you can use <see cref="AttachCustomWheelEventHandler"/> instead.
        /// </remarks>
        /// <param name="customWheelEventHandler">The custom WheelEvent handler to attach.
        /// This is a function that takes a WheelEvent, allowing consumers to stop
        /// propagation and/or prevent the default action. The function returns
        /// whether the event should be processed by xterm.js.</param>
        public ValueTask SetCustomWheelEventHandler(string customWheelEventHandler = "function (event) { return true; }")
        {
            return JSRuntime.InvokeVoidAsync("eval", $"{NAMESPACE_PREFIX}.getTerminalObjectById('{Id}').customWheelEventHandler = {customWheelEventHandler}");
        }

        /// <summary>
        /// Gets the terminal options.
        /// </summary>
        /// <returns></returns>
        public ValueTask<TerminalOptions> GetOptions()
        {
            return JSRuntime.InvokeAsync<TerminalOptions>($"{NAMESPACE_PREFIX}.getOptions", Id);
        }

        /// <summary>
        /// Sets the terminal options.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ValueTask SetOptions(TerminalOptions options)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.setOptions", Id, options);
        }

        /// <summary>
        /// Unfocus the terminal.
        /// </summary>
        public ValueTask Blur()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.blur", Id);
        }

        /// <summary>
        /// Focus the terminal.
        /// </summary>
        public ValueTask Focus()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.focus", Id);
        }

        /// <summary>
        /// Input data to application side. The data is treated the same way input
        /// typed into the terminal would (ie. the onData event will fire).
        /// </summary>
        /// <param name="data">The data to forward to the application.</param>
        /// <param name="wasUserInput">Whether the input is genuine user input. This is true
        /// by default and triggers additionalbehavior like focus or selection
        /// clearing. Set this to false if the data sent should not be treated like
        /// user input would, for example passing an escape sequence to the
        /// application.</param>
        /// <returns></returns>
        public ValueTask Input(string data, bool wasUserInput = true)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.input", Id, data, wasUserInput);
        }

        /// <summary>
        /// Resizes the terminal.
        /// </summary>
        public ValueTask Resize(int columns, int rows)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.resize", Id, columns, rows);
        }

        /// <summary>
        /// Gets whether the terminal has an active selection.
        /// </summary>
        /// <returns></returns>
        public ValueTask<bool> HasSelection()
        {
            return JSRuntime.InvokeAsync<bool>($"{NAMESPACE_PREFIX}.hasSelection", Id);
        }

        /// <summary>
        /// Gets the terminal's current selection, this is useful for implementing
        /// copy behavior outside of xterm.js.
        /// </summary>
        /// <returns></returns>
        public ValueTask<string> GetSelection()
        {
            return JSRuntime.InvokeAsync<string>($"{NAMESPACE_PREFIX}.getSelection", Id);
        }

        /// <summary>
        /// Gets the selection position or undefined if there is no selection.
        /// </summary>
        /// <returns></returns>
        public ValueTask<SelectionPosition> GetSelectionPosition()
        {
            return JSRuntime.InvokeAsync<SelectionPosition>($"{NAMESPACE_PREFIX}.getSelectionPosition", Id);
        }

        /// <summary>
        /// Clears the current terminal selection.
        /// </summary>
        public ValueTask ClearSelection()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.clearSelection", Id);
        }

        /// <summary>
        /// Selects text within the terminal.
        /// </summary>
        /// <param name="column">The column the selection starts at.</param>
        /// <param name="row">The row the selection starts at.</param>
        /// <param name="length">The length of the selection.</param>
        /// <returns></returns>
        public ValueTask Select(int column, int row, int length)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.select", Id, column, row, length);
        }

        /// <summary>
        /// Selects all text within the terminal.
        /// </summary>
        public ValueTask SelectAll()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.selectAll", Id);
        }

        /// <summary>
        /// Selects text in the buffer between 2 lines.
        /// </summary>
        /// <param name="start">The 0-based line index to select from (inclusive).</param>
        /// <param name="end">The 0-based line index to select to (inclusive).</param>
        /// <returns></returns>
        public ValueTask SelectLines(int start, int end)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.selectLines", Id, start, end);
        }

        /// <summary>
        /// Scroll the display of the terminal
        /// </summary>
        /// <param name="amount">The number of lines to scroll down (negative scroll up).</param>
        /// <returns></returns>
        public ValueTask ScrollLines(int amount)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.scrollLines", Id, amount);
        }

        /// <summary>
        /// Scroll the display of the terminal by a number of pages.
        /// </summary>
        /// <param name="pageCount">The number of pages to scroll (negative scrolls up).</param>
        /// <returns></returns>
        public ValueTask ScrollPages(int pageCount)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.scrollPages", Id, pageCount);
        }

        /// <summary>
        /// Scrolls the display of the terminal to the top.
        /// </summary>
        /// <returns></returns>
        public ValueTask ScrollToTop()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.scrollToTop", Id);
        }

        /// <summary>
        /// Scrolls the display of the terminal to the bottom.
        /// </summary>
        /// <returns></returns>
        public ValueTask ScrollToBottom()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.scrollToBottom", Id);
        }

        /// <summary>
        /// Scrolls to a line within the buffer.
        /// </summary>
        /// <param name="line">The 0-based line index to scroll to.</param>
        /// <returns></returns>
        public ValueTask ScrollToLine(int line)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.scrollToLine", Id, line);
        }

        /// <summary>
        /// Clear the entire buffer, making the prompt line the new first line.
        /// </summary>
        /// <returns></returns>
        public ValueTask Clear()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.clear", Id);
        }

        /// <summary>
        /// Write data to the terminal.
        /// </summary>
        /// <param name="data">The data to write to the terminal.</param>
        public ValueTask Write(string data)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.write", Id, data);
        }

        /// <summary>
        /// Write data to the terminal.
        /// </summary>
        /// <param name="data">The data to write to the terminal.</param>
        /// <returns></returns>
        public ValueTask Write(byte[] data)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.write", Id, data);
        }

        /// <summary>
        /// Writes data to the terminal, followed by a break line character (\n).
        /// </summary>
        /// <param name="data">The data to write to the terminal.</param>
        public ValueTask WriteLine(string data)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.writeln", Id, data);
        }

        /// <summary>
        /// Writes data to the terminal, followed by a break line character (\n).
        /// </summary>
        /// <param name="data">The data to write to the terminal.</param>
        /// <returns></returns>
        public ValueTask WriteLine(byte[] data)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.writeln", Id, data);
        }

        /// <summary>
        /// Writes text to the terminal, performing the necessary transformations for pasted text.
        /// </summary>
        /// <param name="data">The text to write to the terminal.</param>
        /// <returns></returns>
        public ValueTask Paste(string data)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.paste", Id, data);
        }

        /// <summary>
        /// Tells the renderer to refresh terminal content between two rows (inclusive) at the next opportunity.
        /// </summary>
        /// <param name="start">The row to start from (between 0 and this.rows - 1).</param>
        /// <param name="end">The row to end at (between start and this.rows - 1).</param>
        /// <returns></returns>
        public ValueTask Refresh(int start, int end)
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.refresh", Id, start, end);
        }

        /// <summary>
        /// Perform a full reset (RIS, aka '\x1bc').
        /// </summary>
        /// <returns></returns>
        public ValueTask Reset()
        {
            return JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.reset", Id);
        }

        /// <summary>
        /// Retrieves the XtermAddon instance associated with the specified addon ID.
        /// </summary>
        /// <param name="addonId">The ID of the addon to retrieve.</param>
        /// <returns>The XtermAddon instance associated with the specified addon ID.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the specified addon is not associated with any terminal.</exception>
        public XtermAddon Addon(string addonId)
        {
            if (_xtermAddons.TryGetValue(addonId, out XtermAddon? addon))
            {
                return addon;
            }

            throw new InvalidOperationException("This addon is not associated with this terminal. Please ensure that the addon is activated on a terminal.");
        }

        /// <inheritdoc />
        public async ValueTask DisposeAsync()
        {
            // Check if the ElementReference.Id is not empty before disposing the terminal
            // This is necessary because an empty Id may be passed to DisposeAsync
            if (!string.IsNullOrEmpty(Id))
            {
                XtermHandler.RemoveTerminal(Id);

                try
                {
                    // Possible .NET 5 SignalR bug, should be fixed in .NET 6
                    // Possible TaskCanceledException in .NET 5 when using InvokeVoidAsync
                    // System.Threading.Tasks.TaskCanceledException: A task was canceled.
                    // System.AggregateException: Exceptions were encountered while disposing components. (A task was canceled.) (A task was canceled.)
                    await JSRuntime.InvokeVoidAsync($"{NAMESPACE_PREFIX}.disposeTerminal", Id);
                }
                catch (Exception ex) when (ex.GetType().Name == "JSDisconnectedException")
                {
                    // Fix .NET 6 JSDisconnectedException
                    // Microsoft.JSInterop.JSDisconnectedException: JavaScript interop calls cannot be issued at this time. This is because the circuit has disconnected and is being disposed.
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
