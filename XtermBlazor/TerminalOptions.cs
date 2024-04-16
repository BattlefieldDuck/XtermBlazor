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
        /// marked as experimental/proposed will throw an error. The default is false.
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
        /// The number of columns in the terminal.
        /// </summary>
        [JsonPropertyName("cols")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? Columns { get; set; }

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
        /// Whether to draw custom glyphs for block element and box drawing characters instead of using
        /// the font. This should typically result in better rendering with continuous lines, even when
        /// line height and letter spacing is used. Note that this doesn't work with the DOM renderer
        /// which renders all characters using the font. The default is true.
        /// </summary>
        [JsonPropertyName("customGlyphs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? CustomGlyphs { get; set; }

        /// <summary>
        /// The width of the cursor in CSS pixels when `cursorStyle` is set to 'bar'.
        /// </summary>
        [JsonPropertyName("cursorWidth")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public double? CursorWidth { get; set; }

        /// <summary>
        /// The style of the cursor when the terminal is not focused.
        /// </summary>
        [JsonPropertyName("cursorInactiveStyle")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public CursorInactiveStyle? CursorInactiveStyle { get; set; }

        /// <summary>
        /// Whether input should be disabled.
        /// </summary>
        [JsonPropertyName("disableStdin")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? DisableStdin { get; set; }

#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// A {@link Document} to use instead of the one that xterm.js was attached
        /// to. The purpose of this is to improve support in multi-window
        /// applications where HTML elements may be references across multiple
        /// windows which can cause problems with `instanceof`.
        /// </summary>
        // [JsonPropertyName("documentOverride")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public object? DocumentOverride { get; set; }
#pragma warning restore CS1587 // XML comment is not placed on a valid language element

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
        public string? FontFamily { get; set; }

        /// <summary>
        /// The font weight used to render non-bold text.
        /// </summary>
        [JsonPropertyName("fontWeight")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FontWeight { get; set; }

        /// <summary>
        /// The font weight used to render bold text.
        /// </summary>
        [JsonPropertyName("fontWeightBold")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? FontWeightBold { get; set; }

        /// <summary>
        /// Whether to ignore the bracketed paste mode. When true, this will always
        /// paste without the `\x1b[200~` and `\x1b[201~` sequences, even when the
        /// shell enables bracketed mode.
        /// </summary>
        [JsonPropertyName("ignoreBracketedPasteMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? IgnoreBracketedPasteMode { get; set; }

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

#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// The handler for OSC 8 hyperlinks. Links will use the `confirm` browser
        /// API with a strongly worded warning if no link handler is set.
        ///
        /// When setting this, consider the security of users opening these links,
        /// at a minimum there should be a tooltip or a prompt when hovering or
        /// activating the link respectively.An example of what might be possible is
        /// a terminal app writing link in the form `javascript:...` that runs some
        /// javascript, a safe approach to prevent that is to validate the link
        /// starts with http(s)://.
        /// </summary>
        // [JsonPropertyName("linkHandler")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public LinkHandler? LinkHandler { get; set; }
#pragma warning restore CS1587 // XML comment is not placed on a valid language element

        /// <summary>
        /// What log level to use. The default is 'info'
        /// </summary>
        [JsonPropertyName("logLevel")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public LogLevel? LogLevel { get; set; }

#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// A logger to use instead of `console`.
        /// </summary>
        // [JsonPropertyName("logger")]
        // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        // public Logger Logger { get; set; } = new();
#pragma warning restore CS1587 // XML comment is not placed on a valid language element

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
        /// Whether to rescale glyphs horizontally that are a single cell wide but
        /// have glyphs that would overlap following cell(s). This typically happens
        /// for ambiguous width characters (eg. the roman numeral characters U+2160+)
        /// which aren't featured in monospace fonts. Emoji glyphs are never
        /// rescaled. This is an important feature for achieving GB18030 compliance.
        /// <br /><br />
        /// Note that this doesn't work with the DOM renderer. The default is false.
        /// </summary>
        [JsonPropertyName("rescaleOverlappingGlyphs")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? RescaleOverlappingGlyphs { get; set; }

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
        /// Whether to scroll to the bottom whenever there is some user input. The
        /// default is true.
        /// </summary>
        [JsonPropertyName("scrollOnUserInput")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? ScrollOnUserInput { get; set; }

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
        [JsonPropertyName("theme")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Theme Theme { get; set; } = new();

        /// <summary>
        /// Whether "Windows mode" is enabled. Because Windows backends winpty and
        /// conpty operate by doing line wrapping on their side, xterm.js does not
        /// have access to wrapped lines.When Windows mode is enabled the following
        /// changes will be in effect:
        ///
        /// - Reflow is disabled.
        /// - Lines are assumed to be wrapped if the last character of the line is
        ///   not whitespace.
        ///
        /// When using conpty on Windows 11 version >= 21376, it is recommended to
        /// disable this because native text wrapping sequences are output correctly
        /// thanks to https://github.com/microsoft/terminal/issues/405
        ///
        /// @deprecated Use {@link windowsPty}. This value will be ignored if
        /// windowsPty is set.
        /// </summary>
        [JsonPropertyName("windowsMode")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public bool? WindowsMode { get; set; }

        /// <summary>
        /// Compatibility information when the pty is known to be hosted on Windows.
        /// Setting this will turn on certain heuristics/workarounds depending on the
        /// values:
        ///
        /// - `if (backend !== undefined || buildNumber !== undefined)`
        ///   - When increasing the rows in the terminal, the amount increased into
        ///     the scrollback. This is done because ConPTY does not behave like
        ///     expect scrollback to come back into the viewport, instead it makes
        ///     empty rows at of the viewport. Not having this behavior can result in
        ///     missing data as the rows get replaced.
        /// - `if !(backend === 'conpty' and buildNumber >= 21376)`
        ///   - Reflow is disabled
        ///   - Lines are assumed to be wrapped if the last character of the line is
        ///     not whitespace.
        /// </summary>
        [JsonPropertyName("windowsPty")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public WindowsPty? WindowsPty { get; set; }

        /// <summary>
        /// A string containing all characters that are considered word separated by the
        /// double click to select work logic.
        /// </summary>
        [JsonPropertyName("wordSeparator")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? WordSeparator { get; set; }


#pragma warning disable CS1587 // XML comment is not placed on a valid language element
        /// <summary>
        /// Enable various window manipulation and report features.
        /// All features are disabled by default for security reasons.
        /// </summary>
        //[JsonPropertyName("windowOptions")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public WindowOptions? WindowOptions { get; set; }
#pragma warning restore CS1587 // XML comment is not placed on a valid language element

        /// <summary>
        /// The width, in pixels, of the canvas for the overview ruler. The overview
        /// ruler will be hidden when not set.
        /// </summary>
        [JsonPropertyName("overviewRulerWidth")]

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? OverviewRulerWidth { get; set; }
    }

    /// <summary>
    /// The style of the cursor.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CursorStyle
    {
        /// <summary>
        /// Block
        /// </summary>
        [EnumMember(Value = "block")]
        Block,

        /// <summary>
        /// Underline
        /// </summary>
        [EnumMember(Value = "underline")]
        Underline,

        /// <summary>
        /// Bar
        /// </summary>
        [EnumMember(Value = "bar")]
        Bar
    }

    /// <summary>
    /// The style of the cursor when the terminal is not focused.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum CursorInactiveStyle
    {
        /// <summary>
        /// Outline
        /// </summary>
        [EnumMember(Value = "outline")]
        Outline,

        /// <summary>
        /// Block
        /// </summary>
        [EnumMember(Value = "block")]
        Block,

        /// <summary>
        /// Bar
        /// </summary>
        [EnumMember(Value = "bar")]
        Bar,

        /// <summary>
        /// Underline
        /// </summary>
        [EnumMember(Value = "underline")]
        Underline,

        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "none")]
        None
    }

    /// <summary>
    /// The modifier key hold to multiply scroll speed.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum FastScrollModifier
    {
        /// <summary>
        /// None
        /// </summary>
        [EnumMember(Value = "none")]
        None,

        /// <summary>
        /// Alt
        /// </summary>
        [EnumMember(Value = "alt")]
        Alt,

        /// <summary>
        /// Ctrl
        /// </summary>
        [EnumMember(Value = "ctrl")]
        Ctrl,

        /// <summary>
        /// Shift
        /// </summary>
        [EnumMember(Value = "shift")]
        Shift
    }

    /// <summary>
    /// What log level to use.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum LogLevel
    {
        /// <summary>
        /// Trace
        /// </summary>
        [EnumMember(Value = "trace")]
        Trace,

        /// <summary>
        /// Debug
        /// </summary>
        [EnumMember(Value = "debug")]
        Debug,

        /// <summary>
        /// Info (default)
        /// </summary>
        [EnumMember(Value = "info")]
        Info,

        /// <summary>
        /// Warn
        /// </summary>
        [EnumMember(Value = "warn")]
        Warn,

        /// <summary>
        /// Error
        /// </summary>
        [EnumMember(Value = "error")]
        Error,

        /// <summary>
        /// Off
        /// </summary>
        [EnumMember(Value = "off")]
        Off
    }

    /// <summary>
    /// The type of renderer to use, this allows using the fallback DOM renderer when canvas is too slow for the environment.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum RendererType
    {
        /// <summary>
        /// Dom
        /// </summary>
        [EnumMember(Value = "dom")]
        Dom,

        /// <summary>
        /// Canvas
        /// </summary>
        [EnumMember(Value = "canvas")]
        Canvas
    }
}
