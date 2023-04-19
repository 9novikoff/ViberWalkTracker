using Newtonsoft.Json;

namespace ViberWalkTracker.ViberModels.DeliveryModels
{
    public class MessageToSend
    {
        public string Receiver { get; set; }
        public double Min_api_version { get; set; }
        public Sender Sender { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }

    }
}
