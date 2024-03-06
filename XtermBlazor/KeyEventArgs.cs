using System;
using Microsoft.AspNetCore.Components.Web;

namespace XtermBlazor
{
    /// <summary>
    /// Key event data
    /// </summary>
    public class KeyEventArgs : EventArgs
    {
        /// <summary>
        /// The pressed key interpreted by xterm.js
        /// </summary>
        public string Key { get; set; } = string.Empty;

        /// <summary>
        /// Keyboard DOM event
        /// </summary>
        public KeyboardEventArgs DomEvent { get; set; } = new();
    }
}
