using CreatureWars.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Declarations
{
    interface IActionAnnouncer
    {
        void ErrorTargetDead(Creature target);
        void AfterMeleeAttack(Creature dealer, Creature target, int damage, int remained);
        void AfterAbilityOnTarget(Creature dealer, Creature target, Ability ability);
        void AfterModifierDamage(Creature target, Modifier modifier);
        void AfterModifierApplied(Creature target, Modifier modifier);
        void AfterModifierEnded(Creature target, Modifier modifier);
        void AfterHeal(Creature creature, int healed);
        void AfterHeal(Creature creature, int healed, Modifier modifier);
        void AfterDead(Creature creature);
    }
}
