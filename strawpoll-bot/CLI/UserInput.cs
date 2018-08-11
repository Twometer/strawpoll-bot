using System.IO;

namespace StrawpollBot.CLI
{
    internal class UserInput
    {
        public string PollId { get; }
        public int ChoiceIdx { get; }
        public int VoteCount { get; }
        public FileInfo ProxyList { get; }

        public UserInput(string pollId, int choiceIdx, int voteCount, FileInfo proxyList)
        {
            PollId = pollId;
            ChoiceIdx = choiceIdx;
            VoteCount = voteCount;
            ProxyList = proxyList;
        }
    }
}
