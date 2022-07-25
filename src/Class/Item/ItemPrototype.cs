using System.Collections.Generic;
using System.Linq;


namespace CreatureWars.Class
{
    class ItemPrototype : ItemBase
    {
        public List<ModifierPrototype> ModifierPrototypes { get; set; }
        public ItemType ItemType { get; }

        public ItemPrototype(ItemType itemType)
        {
            this.ItemType = itemType;
        }

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
