using System.Runtime.CompilerServices;

namespace ViberWalkTracker.ViberModels.ReceivedModels
{
    public class Message
    {
        public string Type { get; set; }
        public string Text { get; set; }
        public string Media { get; set; }
        public Location Location { get; set; }
        public string Tracking_data { get; set; }
    }
}
