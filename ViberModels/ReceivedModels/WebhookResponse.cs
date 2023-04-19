using Newtonsoft.Json;

namespace ViberWalkTracker.ViberModels.ReceivedModels
{
    public class WebhookResponse
    {
        public string Event { get; set; }
        public long Timestamp { get; set; }
        public long Message_token { get; set; }
    }
}
;