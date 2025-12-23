using System.Text.Json.Serialization;

namespace XtermBlazor
{
    /// <summary>
    /// Options for the overview ruler displayed to the right of the terminal.
    /// Note: the overview ruler is only visible when <see cref="Width"/> is set.
    /// </summary>
    public class OverviewRulerOptions
    {
        /// <summary>
        /// When defined, renders decorations in the overview ruler to the right of
        /// the terminal. This must be set in order to see the overview ruler.
        /// </summary>
        [JsonPropertyName("width")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Width { get; set; }

        /// <summary>
        /// Whether to show the top border of the overview ruler, which uses the
        /// theme's overview ruler border color.
        /// </summary>
        [JsonPropertyName("showTopBorder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowTopBorder { get; set; }

        /// <summary>
        /// Whether to show the bottom border of the overview ruler, which uses the
        /// theme's overview ruler border color.
        /// </summary>
        [JsonPropertyName("showBottomBorder")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ShowBottomBorder { get; set; }
    }
}
