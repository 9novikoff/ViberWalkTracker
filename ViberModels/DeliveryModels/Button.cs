using System.Text.Json.Serialization;

namespace ViberWalkTracker.ViberModels.DeliveryModels
{
    public class Button
    {
        [JsonPropertyName("ActionType")]
        public string ActionType { get; set; }

        [JsonPropertyName("ActionBody")]
        public string ActionBody { get; set; }

        [JsonPropertyName("Text")]
        public string Text { get; set; }

        [JsonPropertyName("TextSize")]
        public string TextSize { get; set; }
    }
}
