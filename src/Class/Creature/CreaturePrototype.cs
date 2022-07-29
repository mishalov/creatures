using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CreatureWars.Class
{
    class CreaturePrototype : CreatureBase
    {
        public List<ItemPrototype> Items { get; set; } = new List<ItemPrototype>();
        public List<AbilityPrototype> Abilities { get; set; } = new List<AbilityPrototype>();
        public List<ModifierPrototype> Modifiers { get; set; } = new List<ModifierPrototype>();
        public List<ItemType> ItemTypes { get; set; } = new List<ItemType>();


        public Creature CreateInstance(IMeleeHitHandler MeleeDamageHandler)
        {
            Creature newCreature = new Creature(Name, MeleeDamageHandler);
            newCreature.Items = Items.Select(el => el.CreateInstance()).ToList();
            newCreature.Modifiers = Modifiers.Select(el => el.CreateInstance()).ToList();
            newCreature.Abilities = Abilities.Select(el => el.CreateInstance()).ToList();

            newCreature.HitPoints = MaxHitPoints;
            newCreature.Attributes = Attributes.Clone();
            newCreature.Description = Description;

            return newCreature;
        }
    }
}
