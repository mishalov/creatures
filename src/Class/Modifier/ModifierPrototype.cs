using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{

    public class ModifierPrototype : ModifierBase
    {
        public ModifierPrototype(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public Modifier CreateInstance()
        {
            Modifier modifier = new Modifier(Name, Description);
            modifier.Attributes = Attributes.Clone();
            modifier.Damage = Damage;
            modifier.Heal = Heal;
            modifier.Duration = Duration;
            modifier.Tick = Tick;
            modifier.PossibleTargets = this.PossibleTargets;
            return modifier;
        }
    }
}
