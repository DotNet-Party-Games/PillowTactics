using PillowFight.Repositories.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.Api.Models
{
    public class CharacterCreationDetails
    {
        public string Name { get; set; }

        public CharacterClassEnum Class { get; set; }
    }
}
