using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace XtermBlazor
{
    public static class XtermHandler
    {
        private static readonly Dictionary<string, Xterm> _terminals = new Dictionary<string, Xterm>();

        public static void RegisterTerminal(Xterm terminal)
        {
            _terminals[terminal.ElementReference.Id] = terminal;
        }

        public static void DisposeTerminal(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                _terminals.Remove(referenceId);
            }
        }

        [JSInvokable]
        public static async Task OnBinary(string referenceId, string data)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnBinary.InvokeAsync(data);
            }
        }

        [JSInvokable]
        public static async Task OnCursorMove(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnCursorMove.InvokeAsync();
            }
        }

        [JSInvokable]
        public static async Task OnData(string referenceId, string data)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnData.InvokeAsync(data);
            }
        }

        [JSInvokable]
        public static async Task OnKey(string referenceId, KeyboardEventArgs @event)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnKey.InvokeAsync(@event);
            }
        }

        [JSInvokable]
        public static async Task OnLineFeed(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnLineFeed.InvokeAsync();
            }
        }

        [JSInvokable]
        public static async Task OnScroll(string referenceId, int newPosition)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnScroll.InvokeAsync(newPosition);
            }
        }

        [JSInvokable]
        public static async Task OnSelectionChange(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnSelectionChange.InvokeAsync();
            }
        }

        [JSInvokable]
        public static async Task OnRender(string referenceId, RenderEventArgs @event)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnRender.InvokeAsync(@event);
            }
        }

        [JSInvokable]
        public static async Task OnResize(string referenceId, ResizeEventArgs @event)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnResize.InvokeAsync(@event);
            }
        }

        [JSInvokable]
        public static async Task OnTitleChange(string referenceId)
        {
            if (_terminals.ContainsKey(referenceId))
            {
                await _terminals[referenceId].OnTitleChange.InvokeAsync();
            }
        }

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
