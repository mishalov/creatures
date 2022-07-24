﻿using CreatureWars.Declarations;
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
        protected Timer _pereodicsTimer;

        protected void TickPereodics(object state)
        {
            if (_isDead) return;
            List<Modifier> modifiersToRemove = new List<Modifier>();
            // Deep copy for list of modifiers, because some of them could be removed in process
            List<Modifier> _modifiers = Modifiers.Select(el => el).ToList();
            foreach (Modifier modifier in _modifiers)
            {
                if (modifier.Damage > 0)
                {
                    this.GetDamage(modifier.Damage);
                    Game.Announcer.AfterModifierDamage(this, modifier);
                }
                if (modifier.Heal > 0)
                {
                    this.GetHeal(modifier.Heal);
                    Game.Announcer.AfterHeal(this, modifier.Heal, modifier);
                }
                if (modifier.Duration > 0)
                    modifier.Duration -= 1;
                if (modifier.Duration == 0)
                {
                    modifiersToRemove.Add(modifier);
                }
            }

            modifiersToRemove.ForEach(modifier => RemoveModifier(modifier));
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
            TimerCallback timerCallback = new TimerCallback(TickPereodics);
            this._pereodicsTimer = new Timer(timerCallback, null, 0, 1000);
        }

        public List<Modifier> RemoveModifier(Modifier modifier)
        {
            this.Modifiers.Remove(modifier);
            Game.Announcer.AfterModifierEnded(this, modifier);
            return Modifiers;
        }

        public List<Modifier> ApplyModifier(Modifier modifier)
        {
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

        public void CastAbility(Creature target, Ability ability)
        {
            if (!Abilities.Contains(ability)) Game.Announcer.CreatureDoesntHaveThisAbility(this, ability);
            foreach (var modifier in ability.Modifiers)
            {
                if (modifier.PossibleTargets == PossibleTargets.Self)
                {
                    this.ApplyModifier(modifier);
                }
                else
                {
                    target.ApplyModifier(modifier);
                }
            }
        }
    }
}
