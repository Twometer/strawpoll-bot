using System;
using StrawpollBot.CLI;

namespace StrawpollBot
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Syntax: strawpoll-bot.exe <poll> <choiceIdx> <voteCount> <proxyList>");
                Console.WriteLine("");
                Console.WriteLine("Poll: Link to the poll or the poll id");
                Console.WriteLine("ChoiceIdx: Zero-based index of the choice");
                Console.WriteLine("VoteCount: Number of votes to generate");
                Console.WriteLine("ProxyList: Path to a proxy list (Optional)");
                return;
            }

            var input = CommandLineParser.ParseInput(args);

            if (input == null)
                return;

            Console.WriteLine("Poll Id: " + input.PollId);
            Console.WriteLine("Choice Index: " + input.ChoiceIdx);
            Console.WriteLine("Vote count: " + input.VoteCount);
            Console.WriteLine("Proxy list: " + (input.ProxyList != null ? input.ProxyList.Name : "Do not use"));

        }
    }
}
