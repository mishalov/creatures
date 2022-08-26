using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    public enum PossibleTargets
    {
        Self,
        Target
    }

    public abstract class ModifierBase : GameObject, INameable
    {
        public Attributes Attributes = new Attributes();
        public int Damage { get; set; }
        public int Heal { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string ProgramName { get; set; }
        public ICollection<PossibleTargets> PossibleTargets { get; set; }

        /** 
         * time in seconds before Heal or Damage if duration is set and applied on creature; if set to 0 heal or damage will be applied once
         */
        public double Tick { get; set; }
    }
}
