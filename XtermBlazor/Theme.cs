using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace XtermBlazor
{
    public class Theme
    {
        [JsonPropertyName("background")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Background { get; set; }

        [JsonPropertyName("black")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Black { get; set; }
        
        [JsonPropertyName("blue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Blue { get; set; }

        [JsonPropertyName("brightBlack")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BrightBlack { get; set; }

        [JsonPropertyName("brightBlue")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BrightBlue { get; set; }

        [JsonPropertyName("brightCyan")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string brightCyan { get; set; }

        [JsonPropertyName("brightGreen")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BrightGreen { get; set; }

        [JsonPropertyName("brightMagenta")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BrightMagenta { get; set; }

        [JsonPropertyName("brightRed")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BrightRed { get; set; }

        [JsonPropertyName("brightWhite")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BrightWhite { get; set; }

        [JsonPropertyName("brightYellow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BrightYellow { get; set; }

        [JsonPropertyName("cursor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Cursor { get; set; }

        [JsonPropertyName("cursorAccent")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string CursorAccent { get; set; }

        [JsonPropertyName("cyan")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Cyan { get; set; }

        [JsonPropertyName("foreground")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Foreground { get; set; }

        [JsonPropertyName("green")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Green { get; set; }

        [JsonPropertyName("magenta")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Magenta { get; set; }

        [JsonPropertyName("red")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Red { get; set; }

        [JsonPropertyName("selection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Selection { get; set; }

        [JsonPropertyName("white")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string White { get; set; }

        [JsonPropertyName("yellow")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Yellow { get; set; }


    }
}
