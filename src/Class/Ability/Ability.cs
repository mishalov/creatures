using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    class Ability : AbilityPrototype
    {
        public List<Modifier> Modifiers { get; set; }
    }
}
