using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace MiniGameTC {
    public static class SlackNotifier {
        private static readonly string _webhookUrl = "https://hooks.slack.com/services/";

        public static async void SendMessage(string message)
        {
            using (var client = new HttpClient()) {
                var payload = new {
                    text = message
                };
                var serializedPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");

                await client.PostAsync(_webhookUrl, content);
            }
        }
    }
}