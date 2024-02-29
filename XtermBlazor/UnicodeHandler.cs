namespace XtermBlazor
{
    /// <summary>
    /// Handles Unicode characters.
    /// </summary>
    public class UnicodeHandler
    {
        /// <summary>
        /// Converts a string to its Unicode representation.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The Unicode representation of the input string.</returns>
        public static string StringToUnicode(string input)
        {
            System.Text.StringBuilder unicodeStringBuilder = new System.Text.StringBuilder();
            foreach (char c in input)
            {
                if ((int)c <= 0xFFFF)
                {
                    unicodeStringBuilder.AppendFormat("\\u{0:X4}", (int)c);
                }
                else
                {
                    unicodeStringBuilder.AppendFormat("\\U{0:X8}", (int)c);
                }
            }
            return unicodeStringBuilder.ToString();
        }
    }
}
