using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace XtermBlazor
{
    /// <summary>
    /// An object containing start up options for the terminal.
    /// <see href="https://github.com/xtermjs/xterm.js/blob/master/typings/xterm.d.ts#L31">https://github.com/xtermjs/xterm.js/blob/master/typings/xterm.d.ts#L31</see>
    /// </summary>
    public class TerminalOptions
    {
        /// <summary>
        /// Whether to allow the use of proposed API. When false, any usage of APIs
        /// marked as experimental/proposed will throw an error. This defaults to
        /// true currently, but will change to false in v5.0.
        /// </summary>
        [JsonPropertyName("allowProposedApi")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowProposedApi { get; set; }

        /// <summary>
        /// Whether background should support non-opaque color. It must be set before
        /// executing the `Terminal.open()` method and can't be changed later without
        /// executing it again. Note that enabling this can negatively impact 
        /// performance.
        /// </summary>
        [JsonPropertyName("allowTransparency")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AllowTransparency { get; set; }

        /// <summary>
        /// If enabled, alt + click will move the prompt cursor to position
        /// underneath the mouse. The default is true.
        /// </summary>
        [JsonPropertyName("altClickMovesCursor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? AltClickMovesCursor { get; set; }

        /// <summary>
        /// A data uri of the sound to use for the bell when `bellStyle = 'sound'`.
        /// </summary>
        [JsonPropertyName("bellSound")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string BellSound { get; set; }

        /// <summary>
        /// The type of the bell notification the terminal will use.
        /// </summary>
        [JsonPropertyName("bellStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public BellStyle? BellStyle { get; set; }

        /// <summary>
        /// When enabled the cursor will be set to the beginning of the next line
        /// with every new line. This is equivalent to sending '\r\n' for each '\n'.
        /// Normally the termios settings of the underlying PTY deals with the
        /// translation of '\n' to '\r\n' and this setting should not be used.If you
        /// deal with data from a non-PTY related source, this settings might be
        /// useful.
        /// </summary>
        [JsonPropertyName("convertEol")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ConvertEOL { get; set; }

        /// <summary>
        /// The number of columns in the terminal.
        /// </summary>
        [JsonPropertyName("cols")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Columns { get; set; }

        /// <summary>
        /// Whether the cursor blinks.
        /// </summary>
        [JsonPropertyName("cursorBlink")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CursorBlink { get; set; }

        /// <summary>
        /// The style of the cursor.
        /// </summary>
        [JsonPropertyName("cursorStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CursorStyle? CursorStyle { get; set; }

        /// <summary>
        /// The width of the cursor in CSS pixels when `cursorStyle` is set to 'bar'.
        /// </summary>
        [JsonPropertyName("cursorWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? CursorWidth { get; set; }

        /// <summary>
        /// Whether input should be disabled.
        /// </summary>
        [JsonPropertyName("disableStdin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableStdin { get; set; }

        /// <summary>
        /// Whether to draw bold text in bright colors. The default is true.
        /// </summary>
        [JsonPropertyName("drawBoldTextInBrightColors")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DrawBoldTextInBrightColors { get; set; }

        /// <summary>
        /// The modifier key hold to multiply scroll speed.
        /// </summary>
        [JsonPropertyName("fastScrollModifier")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public FastScrollModifier? FastScrollModifier { get; set; }

        /// <summary>
        /// The scroll speed multiplier used for fast scrolling.
        /// </summary>
        [JsonPropertyName("fastScrollSensitivity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FastScrollSensitivity { get; set; }

        /// <summary>
        /// The font size used to render text.
        /// </summary>
        [JsonPropertyName("fontSize")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? FontSize { get; set; }

        /// <summary>
        /// The font family used to render text.
        /// </summary>
        [JsonPropertyName("fontFamily")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FontFamily { get; set; }

        /// <summary>
        /// The font weight used to render non-bold text.
        /// </summary>
        [JsonPropertyName("fontWeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FontWeight { get; set; }

        /// <summary>
        /// The font weight used to render bold text.
        /// </summary>
        [JsonPropertyName("fontWeightBold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string FontWeightBold { get; set; }

        /// <summary>
        /// The spacing in whole pixels between characters.
        /// </summary>
        [JsonPropertyName("letterSpacing")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? LetterSpacing { get; set; }

        /// <summary>
        /// The line height used to render text.
        /// </summary>
        [JsonPropertyName("lineHeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? LineHeight { get; set; }

        /// <summary>
        /// What log level to use. The default is 'info'
        /// </summary>
        [JsonPropertyName("logLevel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LogLevel? LogLevel { get; set; }

        /// <summary>
        /// Whether to treat option as the meta key.
        /// </summary>
        [JsonPropertyName("macOptionIsMeta")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MacOptionIsMeta { get; set; }

        /// <summary>
        /// Whether holding a modifier key will force normal selection behavior,
        /// regardless of whether the terminal is in mouse events mode. This will
        /// also prevent mouse events from being emitted by the terminal. For
        /// example, this allows you to use xterm.js' regular selection inside tmux
        /// with mouse mode enabled.
        /// </summary>
        [JsonPropertyName("macOptionClickForcesSelection")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? MacOptionClickForcesSelection { get; set; }

        /// <summary>
        /// The minimum contrast ratio for text in the terminal, setting this will
        /// change the foreground color dynamically depending on whether the contrast
        /// ratio is met. Example values:
        /// <br /><br />
        /// - 1: The default, do nothing.<br />
        /// - 4.5: Minimum for WCAG AA compliance.<br />
        /// - 7: Minimum for WCAG AAA compliance.<br />
        /// - 21: White on black or black on white.
        /// </summary>
        [JsonPropertyName("minimumContrastRatio")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? MinimumContrastRatio { get; set; }

        /// <summary>
        /// The type of renderer to use, this allows using the fallback DOM renderer
        /// when canvas is too slow for the environment. The following features do
        /// not work when the DOM renderer is used:
        /// <br /><br />
        /// - Letter spacing<br />
        /// - Cursor blink
        /// </summary>
        [JsonPropertyName("rendererType")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public RendererType? RendererType { get; set; }

        /// <summary>
        /// Whether to select the word under the cursor on right click, this is
        /// standard behavior in a lot of macOS applications.
        /// </summary>
        [JsonPropertyName("rightClickSelectsWord")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RightClickSelectsWord { get; set; }

        /// <summary>
        /// The number of rows in the terminal.
        /// </summary>
        [JsonPropertyName("rows")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Rows { get; set; }

        /// <summary>
        /// Whether screen reader support is enabled. When on this will expose
        /// supporting elements in the DOM to support NVDA on Windows and VoiceOver
        /// on macOS.
        /// </summary>
        [JsonPropertyName("screenReaderMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ScreenReaderMode { get; set; }

        /// <summary>
        /// The amount of scrollback in the terminal. Scrollback is the amount of
        /// rows that are retained when lines are scrolled beyond the initial
        /// viewport.
        /// </summary>
        [JsonPropertyName("scrollback")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Scrollback { get; set; }

        /// <summary>
        /// The scrolling speed multiplier used for adjusting normal scrolling speed.
        /// </summary>
        [JsonPropertyName("scrollSensitivity")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? ScrollSensitivity { get; set; }

        /// <summary>
        /// The size of tab stops in the terminal.
        /// </summary>
        [JsonPropertyName("tabStopWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? TabStopWidth { get; set; }

        /// <summary>
        /// The color theme of the terminal.
        /// </summary>
        //[JsonPropertyName("theme")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public Theme? Theme { get; set; }

        /// <summary>
        /// Whether "Windows mode" is enabled. Because Windows backends winpty and
        /// conpty operate by doing line wrapping on their side, xterm.js does not
        /// have access to wrapped lines. When Windows mode is enabled the following
        /// changes will be in effect:<br />
        /// <br /><br />
        /// - Reflow is disabled.<br />
        /// - Lines are assumed to be wrapped if the last character of the line is
        ///   not whitespace.
        /// </summary>
        [JsonPropertyName("windowsMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? WindowsMode { get; set; }

        /// <summary>
        /// A string containing all characters that are considered word separated by the
        /// double click to select work logic.
        /// </summary>
        [JsonPropertyName("wordSeparator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string WordSeparator { get; set; }

        /// <summary>
        /// Enable various window manipulation and report features.
        /// All features are disabled by default for security reasons.
        /// </summary>
        //[JsonPropertyName("windowOptions")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public WindowOptions? WindowOptions { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum BellStyle
    {
        [EnumMember(Value = "none")]
        None,

        [EnumMember(Value = "sound")]
        Sound
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CursorStyle
    {
        [EnumMember(Value = "block")]
        Block,

        [EnumMember(Value = "underline")]
        Underline,

        [EnumMember(Value = "bar")]
        Bar
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FastScrollModifier
    {
        [EnumMember(Value = "alt")]
        Alt,

        [EnumMember(Value = "ctrl")]
        Ctrl,

        [EnumMember(Value = "shift")]
        Shift
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum LogLevel
    {
        [EnumMember(Value = "debug")]
        Debug,

        [EnumMember(Value = "info")]
        Info,

        [EnumMember(Value = "warn")]
        Warn,

        [EnumMember(Value = "error")]
        Error,

        [EnumMember(Value = "off")]
        Off
    }

    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum RendererType
    {
        [EnumMember(Value = "dom")]
        Dom,

        [EnumMember(Value = "canvas")]
        Canvas
    }
}
