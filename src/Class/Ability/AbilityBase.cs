using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    class AbilityBase : GameObject, INameble
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgramName { get; set; }
        public int Duration { get; set; }
    }
}
