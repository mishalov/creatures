using CreatureWars.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Declarations
{
    public interface IAbilityUseHandler
    {
        int UseAbilityOnTarget(Ability ability, Creature user, Creature target);
        int UseAbilityOnSelf(Ability ability, Creature user);
    }
}
