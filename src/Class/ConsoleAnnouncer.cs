using CreatureWars.Declarations;
using Pastel;
using System;
using System.Drawing;

namespace CreatureWars.Class
{
    internal class ConsoleAnnouncer : IActionAnnouncer
    {
        public class ConsoleAnnouncerColor
        {
            public readonly System.Drawing.Color BackgroundColor;
            public readonly System.Drawing.Color TextColor;

            public ConsoleAnnouncerColor(System.Drawing.Color background, Color text)
            {
                this.BackgroundColor = background;
                this.TextColor = text;
            }
        }

        public readonly ConsoleAnnouncerColor TargetColor = new ConsoleAnnouncerColor(Color.Black, Color.LightGreen);
        public readonly ConsoleAnnouncerColor ActorColor = new ConsoleAnnouncerColor(Color.Black, Color.LightGreen);
        public readonly ConsoleAnnouncerColor ActionColor = new ConsoleAnnouncerColor(Color.Black, Color.White);
        public readonly ConsoleAnnouncerColor AttackColor = new ConsoleAnnouncerColor(Color.Black, Color.Red);
        public readonly ConsoleAnnouncerColor SpellColor = new ConsoleAnnouncerColor(Color.Black, Color.MediumPurple);
        public readonly ConsoleAnnouncerColor DamageColor = new ConsoleAnnouncerColor(Color.Black, Color.Red);
        public readonly ConsoleAnnouncerColor HealColor = new ConsoleAnnouncerColor(Color.Black, Color.ForestGreen);
        public readonly ConsoleAnnouncerColor StandardColor = new ConsoleAnnouncerColor(Color.Black, Color.LightGray);

        public ConsoleAnnouncer() { }

        public ConsoleAnnouncer(ConsoleAnnouncerColor TargetColor,
                            ConsoleAnnouncerColor ActorColor,
                            ConsoleAnnouncerColor ActionColor,
                            ConsoleAnnouncerColor DamageColor,
                            ConsoleAnnouncerColor HealColor,
                            ConsoleAnnouncerColor StandardColor,
                            ConsoleAnnouncerColor AttackColor,
                            ConsoleAnnouncerColor SpellColor)
        {
            this.TargetColor = TargetColor;
            this.ActionColor = ActionColor;
            this.ActorColor = ActorColor;
            this.DamageColor = DamageColor;
            this.HealColor = HealColor;
            this.StandardColor = StandardColor;
            this.AttackColor = AttackColor;
            this.SpellColor = SpellColor;
        }

        private string ActionString(string action)
        {
            return action.Pastel(ActionColor.TextColor).PastelBg(ActionColor.BackgroundColor);
        }

        private string Damage(int damage)
        {
            return damage.ToString().Pastel(DamageColor.TextColor).PastelBg(DamageColor.BackgroundColor);
        }

        private string Actor(string character)
        {
            return character.Pastel(ActorColor.TextColor).PastelBg(ActorColor.BackgroundColor);
        }

        private string Target(string character)
        {
            return character.Pastel(ActorColor.TextColor).PastelBg(ActorColor.BackgroundColor);
        }

        private string RemainedHP(int remained)
        {
            return remained.ToString().Pastel(HealColor.TextColor).PastelBg(HealColor.BackgroundColor);
        }

        private string Ability(string ability)
        {
            return ability.Pastel(SpellColor.TextColor).PastelBg(SpellColor.BackgroundColor);
        }

        private string Heal(int healed)
        {
            return healed.ToString().Pastel(HealColor.TextColor).PastelBg(SpellColor.BackgroundColor);
        }


        public void AfterMeleeAttack(Creature dealer, Creature target, int damage, int remained)
        {
            Console.WriteLine($"{ActionString("Melee Attack!")} {Actor(dealer.Name)} attacks {Target(target.Name)} with {Damage(damage)} damage! {Target(target.Name)} have {RemainedHP(remained)} hitpoints now!");
        }

        public void AfterAbilityOnTarget(Creature dealer, Creature target, Ability ability)
        {
            Console.WriteLine($"{Actor(target.Name)} use {Ability(ability.Name)} on {Target(target.Name)}");
        }

        public void AfterModifierDamage(Creature target, Modifier modifier)
        {
            Console.WriteLine($"{Target(target.Name)} suffers {Damage(modifier.Damage)} from {Ability(modifier.Name)}. {RemainedHP(target.HitPoints)} hitpoints left");
        }

        public void AfterModifierApplied(Creature target, Modifier modifier)
        {
            Console.WriteLine($"{Ability(modifier.Name)} was applied on {Target(target.Name)}");
        }

        public void AfterModifierEnded(Creature target, Modifier modifier)
        {
            Console.WriteLine($"{Ability(modifier.Name)} was disappeared on {Target(target.Name)}");
        }

        public void AfterDead(Creature creature)
        {
            Console.WriteLine($"{Target(creature.Name)} {"is dead".Pastel(AttackColor.TextColor)}. Last hit: ");
        }

        public void AfterHeal(Creature creature, int healed)
        {
            Console.WriteLine($"{Target(creature.Name)} was healed with {Heal(healed)}");
        }

        public void AfterHeal(Creature creature, int healed, Modifier modifier)
        {
            Console.WriteLine($"{Target(creature.Name)} was healed with {Heal(healed)} by {Ability(modifier.Name)} effect. Current hitpoints: {RemainedHP(creature.HitPoints)}");
        }

        public void ErrorTargetDead(Creature target)
        {
            Console.WriteLine($"{Target(target.Name)} already dead!");
        }
    }
}
