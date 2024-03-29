﻿using CreatureWars.Declarations;
using System;

namespace CreatureWars.Class
{
    public class CreatureBase : GameObject, INameable
    {
        // protected int _MaxHitPoints = 1;
        protected int _HitPoints = 0;
        protected Boolean _isDead = false;

        public string Name { get; set; } = "Default Creature";
        public string Description { get; set; }
        public Attributes Attributes { get; set; } = new Attributes();
        public bool IsActionPossible { get { return !_isDead; } }
        public string ProgramName { get; set; }

        public int HitPoints
        {
            get
            {
                return _HitPoints;
            }
            set
            {
                _HitPoints = value >= 0 ? value : 0;
            }
        }

        public int MaxHitPoints
        {
            get
            {
                return Attributes.End * 5;
            }
            // set
            // {
            //     _MaxHitPoints = value > 0 ? value : 1;
            // }
        }

    }
}
