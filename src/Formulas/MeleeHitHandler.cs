using CreatureWars.Class;
using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Formulas
{
    class MeleeHitHandler: IMeleeHitHandler
    {
        public int CalculateMeleeDamage(Creature dealer, Creature target)
        {
            int dealerDamage = dealer.Items.Sum(item => item.Attributes.Str) + dealer.Attributes.Str + dealer.Modifiers.Sum(mod => mod.Attributes.Str);
            int targetArmor = target.Items.Sum(item => item.Attributes.Dex) + target.Attributes.Dex + target.Modifiers.Sum(mod => mod.Attributes.Dex);
            int MaxDealtDamage =  dealerDamage - targetArmor;
            Random rand = new Random(DateTime.UtcNow.Millisecond);
            int dealtDamage = rand.Next(MaxDealtDamage+1);
            return dealtDamage >= 0 ? dealtDamage : 0 ;
        }
    }
}
