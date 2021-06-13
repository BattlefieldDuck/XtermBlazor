using System;

namespace XtermBlazor
{
    public class RenderEventArgs : EventArgs
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
}
