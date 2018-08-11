using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace StrawpollBot.Choice
{
    internal class ChoiceFinder
    {
        public static string FindChoiceId(string pollId, int choiceIdx)
        {
            var request = WebRequest.CreateHttp("https://strawpoll.de/refresh");
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
            request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
            request.Referer = $"https://strawpoll.de/{pollId}";
            request.Headers.Add("X-Requested-With", "XMLHttpRequest");
            var payload = Encoding.UTF8.GetBytes($"pid={pollId}");
            request.ContentLength = payload.Length;
            request.GetRequestStream().Write(payload, 0, payload.Length);
            request.GetRequestStream().Close();
            var response = request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var responseObject = JsonConvert.DeserializeObject<RefreshResponse>(reader.ReadToEnd());
            reader.Close();
            if (choiceIdx >= responseObject.data.Length)
                return null;
            return "check" + responseObject.data[choiceIdx].id;
        }
    }
}
