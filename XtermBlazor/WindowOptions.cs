using System.Text.Json.Serialization;

namespace XtermBlazor
{
    /// <summary>
    /// Options controlling which window operations are enabled/handled.
    /// These map to xterm window manipulation/reporting sequences.
    /// </summary>
    public class WindowOptions
    {
        /// <summary>
        /// Ps=1 De-iconify window. No default implementation.
        /// </summary>
        [JsonPropertyName("restoreWin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RestoreWin { get; set; }

        /// <summary>
        /// Ps=2 Iconify window. No default implementation.
        /// </summary>
        [JsonPropertyName("minimizeWin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MinimizeWin { get; set; }

        /// <summary>
        /// Ps=3 ; x ; y. Move window to [x, y]. No default implementation.
        /// </summary>
        [JsonPropertyName("setWinPosition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? SetWinPosition { get; set; }

        /// <summary>
        /// Ps=4 ; height ; width. Resize the window to given height and width in pixels.
        /// Omitted parameters reuse current values; zero parameters use the display size.
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("setWinSizePixels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? SetWinSizePixels { get; set; }

        /// <summary>
        /// Ps=5 Raise the window to the front of the stacking order. No default implementation.
        /// </summary>
        [JsonPropertyName("raiseWin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RaiseWin { get; set; }

        /// <summary>
        /// Ps=6 Lower the xterm window to the bottom of the stacking order. No default implementation.
        /// </summary>
        [JsonPropertyName("lowerWin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? LowerWin { get; set; }

        /// <summary>
        /// Ps=7 Refresh the window.
        /// </summary>
        [JsonPropertyName("refreshWin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RefreshWin { get; set; }

        /// <summary>
        /// Ps=8 ; height ; width. Resize the text area to given height and width in characters.
        /// Omitted parameters reuse current values; zero parameters use the display size.
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("setWinSizeChars")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? SetWinSizeChars { get; set; }

        /// <summary>
        /// Ps=9 ; 0 Restore maximized window.
        /// Ps=9 ; 1 Maximize window (resize to screen size).
        /// Ps=9 ; 2 Maximize window vertically.
        /// Ps=9 ; 3 Maximize window horizontally.
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("maximizeWin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MaximizeWin { get; set; }

        /// <summary>
        /// Ps=10 ; 0 Undo full-screen mode.
        /// Ps=10 ; 1 Change to full-screen.
        /// Ps=10 ; 2 Toggle full-screen.
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("fullscreenWin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? FullscreenWin { get; set; }

        /// <summary>
        /// Ps=11 Report xterm window state.
        /// If non-iconified: "CSI 1 t". If iconified: "CSI 2 t".
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("getWinState")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetWinState { get; set; }

        /// <summary>
        /// Ps=13 Report xterm window position: "CSI 3 ; x ; y t".
        /// Ps=13 ; 2 Report xterm text-area position: "CSI 3 ; x ; y t".
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("getWinPosition")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetWinPosition { get; set; }

        /// <summary>
        /// Ps=14 Report xterm text area size in pixels: "CSI 4 ; height ; width t".
        /// Ps=14 ; 2 Report xterm window size in pixels: "CSI 4 ; height ; width t".
        /// Has a default implementation.
        /// </summary>
        [JsonPropertyName("getWinSizePixels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetWinSizePixels { get; set; }

        /// <summary>
        /// Ps=15 Report size of the screen in pixels: "CSI 5 ; height ; width t".
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("getScreenSizePixels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetScreenSizePixels { get; set; }

        /// <summary>
        /// Ps=16 Report xterm character cell size in pixels: "CSI 6 ; height ; width t".
        /// Has a default implementation.
        /// </summary>
        [JsonPropertyName("getCellSizePixels")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetCellSizePixels { get; set; }

        /// <summary>
        /// Ps=18 Report the size of the text area in characters: "CSI 8 ; height ; width t".
        /// Has a default implementation.
        /// </summary>
        [JsonPropertyName("getWinSizeChars")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetWinSizeChars { get; set; }

        /// <summary>
        /// Ps=19 Report the size of the screen in characters: "CSI 9 ; height ; width t".
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("getScreenSizeChars")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetScreenSizeChars { get; set; }

        /// <summary>
        /// Ps=20 Report xterm window's icon label: "OSC L label ST".
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("getIconTitle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetIconTitle { get; set; }

        /// <summary>
        /// Ps=21 Report xterm window's title: "OSC l label ST".
        /// No default implementation.
        /// </summary>
        [JsonPropertyName("getWinTitle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? GetWinTitle { get; set; }

        /// <summary>
        /// Ps=22 ; 0 Save xterm icon and window title on stack.
        /// Ps=22 ; 1 Save xterm icon title on stack.
        /// Ps=22 ; 2 Save xterm window title on stack.
        /// All variants have a default implementation.
        /// </summary>
        [JsonPropertyName("pushTitle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PushTitle { get; set; }

        /// <summary>
        /// Ps=23 ; 0 Restore xterm icon and window title from stack.
        /// Ps=23 ; 1 Restore xterm icon title from stack.
        /// Ps=23 ; 2 Restore xterm window title from stack.
        /// All variants have a default implementation.
        /// </summary>
        [JsonPropertyName("popTitle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? PopTitle { get; set; }

        /// <summary>
        /// Ps&gt;=24 Resize to Ps lines (DECSLPP).
        /// DECSLPP is not implemented. This setting is also used to enable/disable DECCOLM.
        /// </summary>
        [JsonPropertyName("setWinLines")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? SetWinLines { get; set; }
    }
}
