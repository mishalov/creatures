using System.Collections.Generic;
using System.Linq;


namespace CreatureWars.Class
{

    public class ItemPrototype : ItemBase
    {
        public List<ModifierPrototype> ModifierPrototypes { get; set; }


        public Item CreateInstance()
        {
            Item item = new Item();
            item.Description = Description;
            item.Name = Name;
            item.Modifiers = ModifierPrototypes.Select(el => el.CreateInstance()).ToList();
            return item;
        }
    }
}
