using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spb.CLI
{
    internal class UserInput
    {
        private string pollId;
        private int choiceIdx;
        private int voteCount;

        public UserInput(string pollId, int choiceIdx, int voteCount)
        {
            this.pollId = pollId;
            this.choiceIdx = choiceIdx;
            this.voteCount = voteCount;
        }
    }
}
