using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    public class AbilityBase : GameObject, INameable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgramName { get; set; }
        public int Duration { get; set; }
        public List<PossibleTargets> PossibleTargets { get; set; }

    }
}
