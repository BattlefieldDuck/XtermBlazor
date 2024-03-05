using System;
using Microsoft.AspNetCore.Components.Web;

namespace XtermBlazor
{
    /// <summary>
    /// OnKey event data
    /// </summary>
    public class KeyEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyEventArgs"/> class.
        /// </summary>
        /// <param name="key">The pressed key interpreted by xterm.js</param>
        /// <param name="domEvent">The keyboard DOM event</param>
        public KeyEventArgs(string key, KeyboardEventArgs domEvent)
        {
            Key = key;
            DomEvent = domEvent;
        }

        /// <summary>
        /// The pressed key interpreted by xterm.js
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// he keyboard DOM event
        /// </summary>
        public KeyboardEventArgs DomEvent { get; set; }
    }
}
