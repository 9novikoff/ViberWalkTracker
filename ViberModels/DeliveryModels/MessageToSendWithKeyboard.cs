namespace ViberWalkTracker.ViberModels.DeliveryModels
{
    public class MessageToSendWithKeyboard
    {
        public string Receiver { get; set; }
        public double Min_api_version { get; set; }
        public string Type { get; set; }
        public string Text { get; set; }
        public Keyboard Keyboard { get; set; }
    }
}
