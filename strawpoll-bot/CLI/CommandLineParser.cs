using System;
using System.IO;
using System.Text.RegularExpressions;

namespace StrawpollBot.CLI
{
    internal class CommandLineParser
    {
        public static UserInput ParseInput(string[] args)
        {
            var pollIdStr = args[0];
            var choiceIdxStr = args[1];
            var countStr = args[2];

            var pollId = pollIdStr;
            var choiceIdx = int.Parse(choiceIdxStr);
            var count = int.Parse(countStr);

            if (Regex.IsMatch(pollIdStr, @"https?:\/\/strawpoll.(com|de)\/.*"))
            {
                pollId = Regex.Replace(pollIdStr, @"https?:\/\/strawpoll.(com|de)\/", "").Trim();
            }

            if (pollId.Length != 7)
            {
                Console.WriteLine("The poll id " + pollId + " has invalid format.");
                return null;
            }

            if (choiceIdx < 0)
            {
                Console.WriteLine("Enter a positive choice index");
                return null;
            }

            if (count <= 0)
            {
                Console.WriteLine("Enter a count > 0");
                return null;
            }

            FileInfo proxyList = null;

            if (args.Length > 3)
            {
                var proxyListStr = args[3];
                if(File.Exists(proxyListStr))
                    proxyList = new FileInfo(proxyListStr);
                else
                {
                    Console.WriteLine("The proxy list file does not exist.");
                    return null;
                }
            }

            return new UserInput(pollId, choiceIdx, count, proxyList);
        }

    }
}
