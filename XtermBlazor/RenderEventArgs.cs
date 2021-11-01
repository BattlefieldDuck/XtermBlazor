using System;

namespace XtermBlazor
{
    /// <summary>
    /// Render event data
    /// </summary>
    public class RenderEventArgs : EventArgs
    {
        /// <summary>
        /// The start row of the rendered area (ranges from `0` to `Terminal.rows - 1`)
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// The end row of the rendered area (ranges from `0` to `Terminal.rows - 1`)
        /// </summary>
        public int End { get; set; }
    }
}
