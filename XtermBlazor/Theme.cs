using System.Text.Json.Serialization;

namespace XtermBlazor
{
    /// <summary>
    /// Contains colors to theme the terminal with.
    /// </summary>
    public class Theme
    {
        /// <summary>
        /// The default foreground color
        /// </summary>
        [JsonPropertyName("foreground")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Foreground { get; set; }

        /// <summary>
        /// The default background color
        /// </summary>
        [JsonPropertyName("background")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Background { get; set; }

        /// <summary>
        /// The cursor color
        /// </summary>
        [JsonPropertyName("cursor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Cursor { get; set; }

        /// <summary>
        /// The accent color of the cursor (fg color for a block cursor)
        /// </summary>
        [JsonPropertyName("cursorAccent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? CursorAccent { get; set; }

        /// <summary>
        /// The selection background color (can be transparent)
        /// </summary>
        [JsonPropertyName("selectionBackground")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SelectionBackground { get; set; }

        /// <summary>
        /// The selection foreground color
        /// </summary>
        [JsonPropertyName("selectionForeground")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SelectionForeground { get; set; }

        /// <summary>
        /// The selection background color when the terminal does not have focus (can be transparent)
        /// </summary>
        [JsonPropertyName("selectionInactiveBackground")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? SelectionInactiveBackground { get; set; }

        /// <summary>
        /// ANSI black (eg. `\x1b[30m`)
        /// </summary>
        [JsonPropertyName("black")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Black { get; set; }

        /// <summary>
        /// ANSI red (eg. `\x1b[31m`)
        /// </summary>
        [JsonPropertyName("red")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Red { get; set; }

        /// <summary>
        /// ANSI green (eg. `\x1b[32m`)
        /// </summary>
        [JsonPropertyName("green")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Green { get; set; }

        /// <summary>
        /// ANSI yellow (eg. `\x1b[33m`)
        /// </summary>
        [JsonPropertyName("yellow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Yellow { get; set; }

        /// <summary>
        /// ANSI blue (eg. `\x1b[34m`)
        /// </summary>
        [JsonPropertyName("blue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Blue { get; set; }

        /// <summary>
        /// ANSI magenta (eg. `\x1b[35m`)
        /// </summary>
        [JsonPropertyName("magenta")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Magenta { get; set; }

        /// <summary>
        /// ANSI cyan (eg. `\x1b[36m`)
        /// </summary>
        [JsonPropertyName("cyan")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Cyan { get; set; }

        /// <summary>
        /// ANSI white (eg. `\x1b[37m`)
        /// </summary>
        [JsonPropertyName("white")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? White { get; set; }

        /// <summary>
        /// ANSI bright black (eg. `\x1b[1;30m`)
        /// </summary>
        [JsonPropertyName("brightBlack")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightBlack { get; set; }

        /// <summary>
        /// ANSI bright red (eg. `\x1b[1;31m`)
        /// </summary>
        [JsonPropertyName("brightRed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightRed { get; set; }

        /// <summary>
        /// ANSI bright green (eg. `\x1b[1;32m`)
        /// </summary>
        [JsonPropertyName("brightGreen")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightGreen { get; set; }

        /// <summary>
        /// ANSI bright yellow (eg. `\x1b[1;33m`)
        /// </summary>
        [JsonPropertyName("brightYellow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightYellow { get; set; }

        /// <summary>
        /// ANSI bright blue (eg. `\x1b[1;34m`)
        /// </summary>
        [JsonPropertyName("brightBlue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightBlue { get; set; }

        /// <summary>
        /// ANSI bright magenta (eg. `\x1b[1;35m`)
        /// </summary>
        [JsonPropertyName("brightMagenta")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightMagenta { get; set; }

        /// <summary>
        /// ANSI bright cyan (eg. `\x1b[1;36m`)
        /// </summary>
        [JsonPropertyName("brightCyan")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightCyan { get; set; }

        /// <summary>
        /// ANSI bright white (eg. `\x1b[1;37m`)
        /// </summary>
        [JsonPropertyName("brightWhite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? BrightWhite { get; set; }
    }
}
