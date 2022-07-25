using System.Collections.Generic;
using CreatureWars.Declarations;

namespace CreatureWars.Class
{
    class ItemType : GameObject, INameble
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxOnCharacter { get; set; }
        public string ProgramName { get; set; }
    }
}
