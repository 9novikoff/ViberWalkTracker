namespace ViberWalkTracker.ViberModels.ReceivedModels
{
    public class ReceivedMessage : WebhookResponse
    {
        public User Sender { get; set; }
        public Message Message { get; set; }
    }
}
