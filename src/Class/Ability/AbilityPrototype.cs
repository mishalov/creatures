using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    class AbilityPrototype : AbilityBase
    {
        public List<ModifierPrototype> ModifierPrototypes { get; set; }

        public AbilityPrototype(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public Ability CreateInstance()
        {
            Ability ability = new Ability(Name, Description);
            ability.Modifiers = ModifierPrototypes.Select(el => el.CreateInstance()).ToList();
            ability.Description = Description;
            ability.Name = Name;
            return ability;
        }
    }
}
