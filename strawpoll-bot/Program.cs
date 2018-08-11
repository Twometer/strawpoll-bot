using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using StrawpollBot.Choice;
using StrawpollBot.CLI;
using StrawpollBot.Proxy;
using StrawpollBot.Voting;

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
            Console.WriteLine();

            Console.WriteLine("Preparing...");
            var choiceId = ChoiceFinder.FindChoiceId(input.PollId, input.ChoiceIdx);
            if (choiceId == null)
            {
                Console.WriteLine("Error: There is no choice with index " + input.ChoiceIdx);
                return;
            }
            Console.WriteLine("Choice id: " + choiceId);

            var proxyList = ProxyListParser.ParseProxyList(input.ProxyList);
            Console.WriteLine("Executing votes...");

            var executor = new VoteExecutor(input.PollId, choiceId);
            var tasks = new List<Task>();
            var doneVotes = 0;

            for (var i = 0; i < input.VoteCount; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    while (true)
                    {
                        if (executor.Vote(proxyList.NextProxy()))
                        {
                            Interlocked.Increment(ref doneVotes);
                            Console.WriteLine($"Finished vote {doneVotes}/{input.VoteCount}");
                            break;
                        }
                    }
                }));
            }

            Task.WaitAll(tasks.ToArray(), -1);
        }
    }
}
