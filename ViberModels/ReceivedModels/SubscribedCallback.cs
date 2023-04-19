using System.Runtime.CompilerServices;

namespace ViberWalkTracker.ViberModels.ReceivedModels
{
    public class SubscribedCallback : WebhookResponse
    {
        public User User { get; set; }
    }
}
