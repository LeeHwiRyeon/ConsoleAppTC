using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace MiniGameTester {
    public static class SlackNotifier {
        private static readonly string webhookUrl = "https://hooks.slack.com/services/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";

        public static async void SendMessage(string message)
        {
            using (var client = new HttpClient()) {
                var payload = new {
                    text = message
                };
                var serializedPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(serializedPayload, Encoding.UTF8, "application/json");

                await client.PostAsync(webhookUrl, content);
            }
        }
    }
}