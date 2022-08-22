using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace CreatureWars.Class
{
    class Creature : CreatureBase
    {

        public List<Item> Items { get; set; } = new List<Item>();
        public List<Ability> Abilities { get; set; } = new List<Ability>();
        public List<Modifier> Modifiers { get; set; } = new List<Modifier>();
        protected IMeleeHitHandler _MeleeDamageHandler;
        protected Timer _periodicTimer;

        //Return modifier that should be removed
        protected Modifier HandleModifier(Modifier modifier)
        {
            if (modifier.Damage > 0 && this.HitPoints > 0)
            {
                this.GetDamage(modifier.Damage);
                Game.Announcer.AfterModifierDamage(this, modifier);
            }
            if (modifier.Heal > 0 && this.HitPoints < this.MaxHitPoints)
            {
                this.GetHeal(modifier.Heal);
                Game.Announcer.AfterHeal(this, modifier.Heal, modifier);
            }
            if (modifier.Duration > 0)
                modifier.Duration -= 1;
            if (modifier.Duration == 0)
            {
                return modifier;
            }
            return null;
        }

        protected void TickPeriodic(object state)
        {
            if (_isDead) return;

            List<Modifier> _modifiers = Modifiers.Select(el => el).ToList();
            var modifiersToRemove = _modifiers.Select((modifier) => HandleModifier(modifier)).Where((modifier) => modifier != null);
            modifiersToRemove.ToList().ForEach(modifier => RemoveModifier(modifier));
        }

        public void KillCreature()
        {
            this._isDead = true;
            Game.Announcer.AfterDead(this);
        }


        public Creature(string name, IMeleeHitHandler MeleeDamageHandler)
        {
            this.Name = name;
            this.HitPoints = MaxHitPoints;
            this._MeleeDamageHandler = MeleeDamageHandler;
            TimerCallback timerCallback = new TimerCallback(TickPeriodic);
            this._periodicTimer = new Timer(timerCallback, null, 0, 1000);
        }

        public List<Modifier> RemoveModifier(Modifier modifier)
        {
            this.Modifiers.Remove(modifier);
            Game.Announcer.AfterModifierEnded(this, modifier);
            return Modifiers;
        }

        public List<Modifier> ApplyModifier(Modifier modifier)
        {
            if (modifier.Duration == 0)
            {
                HandleModifier(modifier);
                return Modifiers;
            }
            Modifiers.Add(modifier);
            Game.Announcer.AfterModifierApplied(this, modifier);
            return Modifiers;
        }

        /**
         * <summary>Method to decrease hitpoints in fact of hit</summary>
         * <param name="damage">Amount of damage</param>
         * <returns>Count of HitPoints left</returns>
         */
        public int GetDamage(int damage)
        {
            int newHitpoints = HitPoints - damage;
            if (newHitpoints <= 0)
            {
                KillCreature();
            }
            HitPoints = HitPoints - damage;

            return HitPoints;
        }

        /**
         * <summary>Method to increase current hitpoints in fact of heal</summary>
         * <param name="healed">Amount of damage</param>
         * <returns>Count of HitPoints left</returns>
         */
        public int GetHeal(int healed)
        {
            int newHitPoints = HitPoints + healed;
            if (newHitPoints > MaxHitPoints)
            {
                newHitPoints = MaxHitPoints;
            }
            HitPoints = newHitPoints;
            return HitPoints;
        }


        /// <summary>Method to deal damage to creature</summary>
        /// <param name="target">Hit creature with melee attack</param>
        /// <returns>Dealt damage</returns>
        public int HitCreatureMelee(Creature target)
        {
            if (!IsActionPossible) return 0;
            if (target._isDead)
            {
                //Game.Announcer.ErrorTargetDead(target);
                return 0;
            }
            int damage = this._MeleeDamageHandler.CalculateMeleeDamage(this, target);
            int remains = target.GetDamage(damage);
            Game.Announcer.AfterMeleeAttack(this, target, damage, remains);
            return damage;
        }

        public bool CastAbility(Creature target, Ability ability)
        {
            Game.Announcer.CreatureUseTargetAbility(this, target, ability);
            if (!Abilities.Contains(ability)) Game.Announcer.CreatureDoesntHaveThisAbility(this, ability);

            if (!ability.PossibleTargets.Contains(PossibleTargets.Self) && target == this){
                Game.Announcer.WrongTarget(this, target, ability);
                return false;
            }

            foreach (var modifier in ability.Modifiers)
            {
                if (modifier.PossibleTargets.Contains(PossibleTargets.Self) )
                {
                    this.ApplyModifier(modifier);
                }
                else
                {
                    target.ApplyModifier(modifier);
                }
            }

            return true;
        }
        public void WearItem(Item item)
        {
            Items.Add(item);
            Game.Announcer.WearItem(this, item);
            item.Modifiers.ForEach((modifier) => ApplyModifier(modifier));
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
            Game.Announcer.RemoveItem(this, item);
            item.Modifiers.ForEach((modifier) => RemoveModifier(modifier));
        }
    }
}
