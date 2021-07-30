using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Interfaces
{
    public interface IPlayerCharacter : ICharacter
    {
        public int PlayerId { get; set; }

        public IPlayer Player { get; set; }

        public int Losses { get; set; }

        public int Wins { get; set; }
    }
}
