using System.Collections.Generic;
using CreatureWars.Declarations;

namespace CreatureWars.Class
{
    public class ItemType : GameObject, INameable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxOnCharacter { get; set; }
        public string ProgramName { get; set; }
    }
}
