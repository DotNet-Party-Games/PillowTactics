using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Interfaces
{
    public interface IPlayerCharacter : ICharacter
    {
        int PlayerId { get; set; }

        public string Player { get; set; }
    }
}
