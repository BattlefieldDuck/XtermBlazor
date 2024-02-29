using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XtermBlazor
{
    /// <summary>
    /// Xterm Handler
    /// </summary>
    public static class XtermHandler
    {
        private static readonly Dictionary<string, Xterm> _terminals = new();

        /// <summary>
        /// Register Terminal
        /// </summary>
        /// <param name="terminal"></param>
        public static void RegisterTerminal(Xterm terminal)
        {
            _terminals[terminal.Id] = terminal;
        }

        /// <summary>
        /// Dispose Terminal
        /// </summary>
        /// <param name="id"></param>
        public static void DisposeTerminal(string id)
        {
            if (_terminals.ContainsKey(id))
            {
                _terminals.Remove(id);
            }
        }

        /// <summary>
        /// Adds an event listener for when the terminal is rendered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnFirstRender(string id)
        {
            return GetTerminalById(id)?.OnFirstRender.InvokeAsync() ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a binary event fires. This is used to
        /// enable non UTF-8 conformant binary messages to be sent to the backend.
        /// Currently this is only used for a certain type of mouse reports that
        /// happen to be not UTF-8 compatible.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnBinary(string id, string data)
        {
            return GetTerminalById(id)?.OnBinary.InvokeAsync(data) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for the cursor moves.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnCursorMove(string id)
        {
            return GetTerminalById(id)?.OnCursorMove.InvokeAsync() ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a data event fires.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnData(string id, string data)
        {
            return GetTerminalById(id)?.OnData.InvokeAsync(data) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a key is pressed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnKey(string id, KeyboardEventArgs @event)
        {
            return GetTerminalById(id)?.OnKey.InvokeAsync(@event) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a key is pressed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnKeyDataEvent(string id, string key)
        {
            return GetTerminalById(id)?.OnKeyDataEvent.InvokeAsync(key) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a line feed is added.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnLineFeed(string id)
        {
            return GetTerminalById(id)?.OnLineFeed.InvokeAsync() ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a scroll occurs.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPosition"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnScroll(string id, int newPosition)
        {
            return GetTerminalById(id)?.OnScroll.InvokeAsync(newPosition) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a selection change occurs.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnSelectionChange(string id)
        {
            return GetTerminalById(id)?.OnSelectionChange.InvokeAsync() ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when rows are rendered.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnRender(string id, RenderEventArgs @event)
        {
            return GetTerminalById(id)?.OnRender.InvokeAsync(@event) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when the terminal is resized.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnResize(string id, ResizeEventArgs @event)
        {
            return GetTerminalById(id)?.OnResize.InvokeAsync(@event) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when an OSC 0 or OSC 2 title change occurs.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnTitleChange(string id, string title)
        {
            return GetTerminalById(id)?.OnTitleChange.InvokeAsync(title) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when the bell is triggered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnBell(string id)
        {
            return GetTerminalById(id)?.OnBell.InvokeAsync() ?? Task.CompletedTask;
        }

        /// <summary>
        /// An event handler before keys are processed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static bool AttachCustomKeyEventHandler(string id, KeyboardEventArgs @event)
        {
            return GetTerminalById(id)?.CustomKeyEventHandler.Invoke(@event) ?? true;
        }

        private static Xterm? GetTerminalById(string id)
        {
            return _terminals.ContainsKey(id) ? _terminals[id] : null;
        }
    }
}
