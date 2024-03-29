﻿using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    public class Ability : AbilityBase
    {
        public List<Modifier> Modifiers { get; set; }
        public Ability(string name, string description, List<PossibleTargets> possibleTargets)
        {
            this.Name = name;
            this.Description = description;
            this.PossibleTargets = possibleTargets;
        }
    }
}
