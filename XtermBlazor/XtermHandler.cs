using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XtermBlazor
{
    /// <summary>
    /// Handles operations related to Xterm terminals.
    /// </summary>
    public static class XtermHandler
    {
        /// <summary>
        /// Stores all the Xterm terminals with their IDs as keys.
        /// </summary>
        private static readonly Dictionary<string, Xterm> _terminals = [];

        /// <summary>
        /// Registers a new Xterm terminal.
        /// </summary>
        /// <param name="terminal">The Xterm terminal to register.</param>
        public static void RegisterTerminal(Xterm terminal)
        {
            _terminals[terminal.Id] = terminal;
        }

        /// <summary>
        /// Removes an Xterm terminal based on its ID.
        /// </summary>
        /// <param name="id">The ID of the Xterm terminal to remove.</param>
        /// <returns>True if the terminal was successfully removed; false otherwise.</returns>
        public static bool RemoveTerminal(string id)
        {
            return _terminals.Remove(id);
        }

        /// <summary>
        /// Adds an event listener that triggers when the terminal is first rendered.
        /// </summary>
        /// <param name="id">The ID of the Xterm terminal.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        [JSInvokable]
        public static Task OnFirstRender(string id)
        {
            return GetTerminal(id)?.OnFirstRender.InvokeAsync() ?? Task.CompletedTask;
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
            return GetTerminal(id)?.OnBinary.InvokeAsync(data) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for the cursor moves.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnCursorMove(string id)
        {
            return GetTerminal(id)?.OnCursorMove.InvokeAsync() ?? Task.CompletedTask;
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
            return GetTerminal(id)?.OnData.InvokeAsync(data) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a key is pressed.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnKey(string id, KeyEventArgs @event)
        {
            return GetTerminal(id)?.OnKey.InvokeAsync(@event) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a line feed is added.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnLineFeed(string id)
        {
            return GetTerminal(id)?.OnLineFeed.InvokeAsync() ?? Task.CompletedTask;
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
            return GetTerminal(id)?.OnScroll.InvokeAsync(newPosition) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when a selection change occurs.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnSelectionChange(string id)
        {
            return GetTerminal(id)?.OnSelectionChange.InvokeAsync() ?? Task.CompletedTask;
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
            return GetTerminal(id)?.OnRender.InvokeAsync(@event) ?? Task.CompletedTask;
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
            return GetTerminal(id)?.OnResize.InvokeAsync(@event) ?? Task.CompletedTask;
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
            return GetTerminal(id)?.OnTitleChange.InvokeAsync(title) ?? Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for when the bell is triggered.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [JSInvokable]
        public static Task OnBell(string id)
        {
            return GetTerminal(id)?.OnBell.InvokeAsync() ?? Task.CompletedTask;
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
            return GetTerminal(id)?.CustomKeyEventHandler.Invoke(@event) ?? true;
        }

        /// <summary>
        /// An event handler before wheel are processed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static bool AttachCustomWheelEventHandler(string id, WheelEventArgs @event)
        {
            return GetTerminal(id)?.CustomWheelEventHandler.Invoke(@event) ?? true;
        }

        private static Xterm? GetTerminal(string id)
        {
            return _terminals.ContainsKey(id) ? _terminals[id] : null;
        }
    }
}
