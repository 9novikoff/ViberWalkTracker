using System.Text.Json.Serialization;

namespace ViberWalkTracker.ViberModels.DeliveryModels
{
    public class Keyboard
    {
        [JsonPropertyName("Type")]
        public string Type { get; set; } = "keyboard";
        [JsonPropertyName("DefaultHeight")]
        public bool DefaultHeight { get; set; } = true;
        [JsonPropertyName("Buttons")]
        public List<Button> Buttons { get; set; }
    }
}
