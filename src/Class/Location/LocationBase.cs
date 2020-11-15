﻿using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    class LocationBase : GameObject, INameble
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
