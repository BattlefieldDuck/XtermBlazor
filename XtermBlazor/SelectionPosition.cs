namespace XtermBlazor
{
    /// <summary>
    /// An object representing a selection within the terminal.
    /// </summary>
    public class SelectionPosition
    {
        /// <summary>
        /// The start column of the selection.
        /// </summary>
        public int StartColumn { get; set; }

        /// <summary>
        /// The start row of the selection.
        /// </summary>
        public int StartRow { get; set; }

        /// <summary>
        /// The end column of the selection.
        /// </summary>
        public int EndColumn { get; set; }

        /// <summary>
        /// The end row of the selection.
        /// </summary>
        public int EndRow { get; set; }
    }
}
