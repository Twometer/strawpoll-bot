using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StrawpollBot.Voting
{
    public class VoteExecutor
    {
        private string pollId;
        private string choiceId;

        public VoteExecutor(string pollId, string choiceId)
        {
            this.pollId = pollId;
            this.choiceId = choiceId;
        }

        public bool Vote(IWebProxy proxy)
        {
            try
            {
                var request = WebRequest.CreateHttp("https://strawpoll.de/vote");
                request.Method = "POST";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.Referer = $"https://strawpoll.de/{pollId}";
                request.Headers.Add("X-Requested-With", "XMLHttpRequest");
                request.Proxy = proxy;
                var payload = Encoding.UTF8.GetBytes($"pid={pollId}&oids={choiceId}");
                request.ContentLength = payload.Length;
                request.GetRequestStream().Write(payload, 0, payload.Length);
                request.GetRequestStream().Close();
                var response = request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                bool success = reader.ReadToEnd().Contains("\"success\":1");
                reader.Close();
                return success;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
