using System;
using Microsoft.AspNetCore.Components.Web;

namespace XtermBlazor
{
    /// <summary>
    /// OnKey event data
    /// </summary>
    public class OnKeyEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OnKeyEvent"/> class.
        /// </summary>
        /// <param name="key">The pressed key interpreted by xterm.js</param>
        /// <param name="event">The keyboard DOM event</param>
        public OnKeyEvent(string key, KeyboardEventArgs @event)
        {
            Key = key;
            Event = @event;
        }

        /// <summary>
        /// The pressed key interpreted by xterm.js
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// he keyboard DOM event
        /// </summary>
        public KeyboardEventArgs Event { get; set; }
    }
}
