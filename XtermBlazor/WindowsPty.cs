using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace XtermBlazor
{
    /// <summary>
    /// Pty information for Windows.
    /// </summary>
    public class WindowsPty
    {
        /// <summary>
        /// What pty emulation backend is being used.
        /// </summary>
        [JsonPropertyName("backend")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Backend? Backend { get; set; }

        /// <summary>
        /// The Windows build version (eg. 19045)
        /// </summary>
        [JsonPropertyName("buildNumber")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? BuildNumber { get; set; }
    }

    /// <summary>
    /// What pty emulation backend is being used.
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public enum Backend
    {
        /// <summary>
        /// ConPTY
        /// </summary>
        [EnumMember(Value = "conpty")]
        ConPTY,

        /// <summary>
        /// WinPTY
        /// </summary>
        [EnumMember(Value = "winpty")]
        WinPTY,
    }
}
