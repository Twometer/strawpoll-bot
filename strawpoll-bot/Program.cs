using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using spb.CLI;

namespace spb
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Syntax: strawpoll-bot.exe <poll> <choiceIdx> <voteCount>");
                Console.WriteLine("");
                Console.WriteLine("Poll: Link to the poll or the poll id");
                Console.WriteLine("ResponseNo: Zero-based index of the choice");
                Console.WriteLine("VoteCount: Number of votes to generate");
                return;
            }

            var input = CommandLineParser.ParseInput(args);


        }

        


    }
}
