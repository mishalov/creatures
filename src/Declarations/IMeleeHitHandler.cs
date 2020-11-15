using CreatureWars.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Declarations
{
    interface IMeleeHitHandler
    { 
        int CalculateMeleeDamage(Creature dealer, Creature target);
    }
}
