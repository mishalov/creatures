using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    class ItemBase : GameObject, INameble
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Attributes Attributes { get; set; }
    }
}
