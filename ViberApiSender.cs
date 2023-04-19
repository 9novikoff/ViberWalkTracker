using Nancy;
using System.Text.Json.Nodes;
using System.Text;
using ViberWalkTracker.ViberModels;
using ViberWalkTracker.ViberModels.DeliveryModels;
using ViberWalkTracker.ViberModels.ReceivedModels;
using Newtonsoft.Json.Linq;
using Azure.Core;
using Newtonsoft.Json;

namespace ViberWalkTracker
{
    public class ViberApiSender
    {
        //will use inheritance when fix json serialization
        public async Task SendMessage(MessageToSend message, string apiUrl)
        {
            using var httpClient = new HttpClient();

            var token = "token";


            httpClient.DefaultRequestHeaders.Add("X-Viber-Auth-Token", token);

            var response = await httpClient.PostAsJsonAsync(apiUrl, message);
        }

        public async Task SendKeyboard(MessageToSendWithKeyboard message, string apiUrl)
        {
            using var httpClient = new HttpClient();

            var token = "token";


            httpClient.DefaultRequestHeaders.Add("X-Viber-Auth-Token", token);

            var response = await httpClient.PostAsJsonAsync(apiUrl, message);
        }
    }
}
