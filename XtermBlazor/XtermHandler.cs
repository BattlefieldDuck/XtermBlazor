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
            _terminals[terminal.ElementReference.Id] = terminal;
        }

        /// <summary>
        /// Dispose Terminal
        /// </summary>
        /// <param name="referenceId"></param>
        public static void DisposeTerminal(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                _terminals.Remove(referenceId);
            }
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
            return _terminals.ContainsKey(id) ? _terminals[id].OnBinary.InvokeAsync(data) : Task.CompletedTask;
        }

        /// <summary>
        /// Adds an event listener for the cursor moves.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnCursorMove(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnCursorMove.InvokeAsync();
            }
        }

        /// <summary>
        /// Adds an event listener for when a data event fires.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnData(string referenceId, string data)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnData.InvokeAsync(data);
            }
        }

        /// <summary>
        /// Adds an event listener for when a key is pressed.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnKey(string referenceId, KeyboardEventArgs @event)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnKey.InvokeAsync(@event);
            }
        }

        /// <summary>
        /// Adds an event listener for when a line feed is added.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnLineFeed(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnLineFeed.InvokeAsync();
            }
        }

        /// <summary>
        /// Adds an event listener for when a scroll occurs.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="newPosition"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnScroll(string referenceId, int newPosition)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnScroll.InvokeAsync(newPosition);
            }
        }

        /// <summary>
        /// Adds an event listener for when a selection change occurs.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnSelectionChange(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnSelectionChange.InvokeAsync();
            }
        }

        /// <summary>
        /// Adds an event listener for when rows are rendered.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnRender(string referenceId, RenderEventArgs @event)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnRender.InvokeAsync(@event);
            }
        }

        /// <summary>
        /// Adds an event listener for when the terminal is resized.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnResize(string referenceId, ResizeEventArgs @event)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnResize.InvokeAsync(@event);
            }
        }

        /// <summary>
        /// Adds an event listener for when an OSC 0 or OSC 2 title change occurs.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnTitleChange(string referenceId, string title)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnTitleChange.InvokeAsync(title);
            }
        }

        /// <summary>
        /// Adds an event listener for when the bell is triggered.
        /// </summary>
        /// <param name="referenceId"></param>
        /// <returns></returns>
        [JSInvokable]
        public static async Task OnBell(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnBell.InvokeAsync();
            }
        }
    }
}
