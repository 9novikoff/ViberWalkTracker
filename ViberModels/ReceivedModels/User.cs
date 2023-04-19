using System.Runtime.CompilerServices;

namespace ViberWalkTracker.ViberModels.ReceivedModels
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Country { get; set; }
        public string Language { get; set; }
        public double Api_version { get; set; }
    }
}
