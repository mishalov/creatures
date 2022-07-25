using CreatureWars.Declarations;
using Pastel;
using System;
using System.Drawing;

namespace CreatureWars.Class
{
    class ConsoleAnnouncer : IActionAnnouncer
    {
        public class ConsoleAnnouncerColor
        {
            public readonly System.Drawing.Color TextColor;

            public ConsoleAnnouncerColor(Color text)
            {
                this.TextColor = text;
            }
        }

        public readonly ConsoleAnnouncerColor TargetColor = new ConsoleAnnouncerColor(Color.LightGreen);
        public readonly ConsoleAnnouncerColor ActorColor = new ConsoleAnnouncerColor(Color.LightGreen);
        public readonly ConsoleAnnouncerColor ActionColor = new ConsoleAnnouncerColor(Color.White);
        public readonly ConsoleAnnouncerColor AttackColor = new ConsoleAnnouncerColor(Color.Red);
        public readonly ConsoleAnnouncerColor SpellColor = new ConsoleAnnouncerColor(Color.MediumPurple);
        public readonly ConsoleAnnouncerColor DamageColor = new ConsoleAnnouncerColor(Color.Red);
        public readonly ConsoleAnnouncerColor HealColor = new ConsoleAnnouncerColor(Color.ForestGreen);
        public readonly ConsoleAnnouncerColor StandardColor = new ConsoleAnnouncerColor(Color.LightGray);
        public readonly ConsoleAnnouncerColor DescriptionColor = new ConsoleAnnouncerColor(Color.Gray);
        public readonly ConsoleAnnouncerColor ErrorColor = new ConsoleAnnouncerColor(Color.Red);

        public ConsoleAnnouncer() { }

        public ConsoleAnnouncer(ConsoleAnnouncerColor TargetColor,
                            ConsoleAnnouncerColor ActorColor,
                            ConsoleAnnouncerColor ActionColor,
                            ConsoleAnnouncerColor DamageColor,
                            ConsoleAnnouncerColor HealColor,
                            ConsoleAnnouncerColor StandardColor,
                            ConsoleAnnouncerColor AttackColor,
                            ConsoleAnnouncerColor SpellColor,
                            ConsoleAnnouncerColor DescriptionColor,
                            ConsoleAnnouncerColor ErrorColor)
        {
            this.TargetColor = TargetColor;
            this.ActionColor = ActionColor;
            this.ActorColor = ActorColor;
            this.DamageColor = DamageColor;
            this.HealColor = HealColor;
            this.StandardColor = StandardColor;
            this.AttackColor = AttackColor;
            this.SpellColor = SpellColor;
            this.ErrorColor = ErrorColor;
        }

        private string ActionString(string action)
        {
            return action.Pastel(ActionColor.TextColor);
        }

        private string Damage(int damage)
        {
            return damage.ToString().Pastel(DamageColor.TextColor);
        }

        private string Actor(string character)
        {
            return character.Pastel(ActorColor.TextColor);
        }

        private string Target(string character)
        {
            return character.Pastel(ActorColor.TextColor);
        }

        private string RemainedHP(int remained)
        {
            return remained.ToString().Pastel(HealColor.TextColor);
        }

        private string Ability(string ability)
        {
            return ability.Pastel(SpellColor.TextColor);
        }

        private string Heal(int healed)
        {
            return healed.ToString().Pastel(HealColor.TextColor);
        }

        private string AbilityDescription(string description)
        {
            return description.ToString().Pastel(DescriptionColor.TextColor);
        }
        private string Error(string Message)
        {
            return Message.Pastel(ErrorColor.TextColor);
        }

        public void AfterMeleeAttack(Creature dealer, Creature target, int damage, int remained)
        {
            Announce($"{Actor(dealer.Name)} attacks {Target(target.Name)} with {Damage(damage)} damage! {Target(target.Name)} have {RemainedHP(remained)} hitpoints now!");
        }

        public void AfterAbilityOnTarget(Creature dealer, Creature target, Ability ability)
        {
            Announce($"{Actor(target.Name)} use {Ability(ability.Name)} on {Target(target.Name)}");
        }

        public void AfterModifierDamage(Creature target, Modifier modifier)
        {
            Announce($"{Target(target.Name)} suffers {Damage(modifier.Damage)} from {Ability(modifier.Name)}. {RemainedHP(target.HitPoints)} hitpoints left");
        }

        public void AfterModifierApplied(Creature target, Modifier modifier)
        {
            Announce($"{Ability(modifier.Name)} was applied on {Target(target.Name)}. {AbilityDescription(modifier.Description)}");
        }

        public void AfterModifierEnded(Creature target, Modifier modifier)
        {
            Announce($"{Ability(modifier.Name)} was disappeared on {Target(target.Name)}");
        }

        public void AfterDead(Creature creature)
        {
            Announce($"{Target(creature.Name)} {"is dead".Pastel(AttackColor.TextColor)}. Last hit: ");
        }

        public void AfterHeal(Creature creature, int healed)
        {
            Announce($"{Target(creature.Name)} was healed with {Heal(healed)}");
        }

        public void AfterHeal(Creature creature, int healed, Modifier modifier)
        {
            Announce($"{Target(creature.Name)} was healed with {Heal(healed)} by {Ability(modifier.Name)} effect. Current hitpoints: {RemainedHP(creature.HitPoints)}");
        }

        public void ErrorTargetDead(Creature target)
        {
            Announce($"{Target(target.Name)} already dead!");
        }

        public void CreatureDoesntHaveThisAbility(Creature caster, Ability ability)
        {
            Announce(Error($"{caster.Name} doesnt have ability {ability.Name}"));
        }

        public void CreatureUseTargetAbility(Creature caster, Creature target, Ability ability)
        {
            Announce($"{Actor(caster.Name)} casts {Ability(ability.Name)} on {Target(target.Name)}");
        }

        public void WearItem(Creature target, Item item)
        {
            Announce($"{Actor(target.Name)} wears {Ability(item.Name)}");
        }

        public void RemoveItem(Creature target, Item item)
        {
            Announce($"{Actor(target.Name)} removes {Ability(item.Name)}");
        }

        private void Announce(string announcement)
        {
            Console.WriteLine(announcement);
        }
    }
}
