using System;

namespace XtermBlazor
{
    public class ResizeEventArgs : EventArgs
    {
        public int Columns { get; set; }
        public int Rows { get; set; }
    }
}
