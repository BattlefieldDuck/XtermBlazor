using System;

namespace XtermBlazor
{
    /// <summary>
    /// Resize event data
    /// </summary>
    public class ResizeEventArgs : EventArgs
    {
        /// <summary>
        /// The number of columns to resize to.
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// The number of rows to resize to.
        /// </summary>
        public int Rows { get; set; }
    }
}
