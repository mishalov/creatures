using CreatureWars.Declarations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatureWars.Class
{
    class Item : ItemBase
    {
        public List<Modifier> Modifiers { get; set; }
    }
}
