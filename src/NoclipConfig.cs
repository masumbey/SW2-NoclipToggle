using System.Text.Json.Serialization;

namespace NoclipTogglePlugin
{
    public class NoclipConfig
    {
        [JsonPropertyName("prefix")]
        public string Prefix { get; set; } =
            "{Gold}[Sunucu Adı] {LightBlue}";

        [JsonPropertyName("enable_message")]
        public string EnableMessage { get; set; } =
            "{Green}adlı yetkili kendine noclip verdi.";

        [JsonPropertyName("disable_message")]
        public string DisableMessage { get; set; } =
            "{Red}adlı yetkili kendine noclip'i kapattı.";
    }
}
