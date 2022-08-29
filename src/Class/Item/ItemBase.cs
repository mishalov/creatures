using CreatureWars.Declarations;


namespace CreatureWars.Class
{
    public enum ItemRarity
    {
        Poor, Common, Uncommon, Rare, Epic, Legendary
    }

    public class ItemBase : GameObject, INameable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgramName { get; set; }
        public Attributes Attributes
        { get; set; }
        public ItemRarity Rarity { get; set; }
        public ItemType ItemType { get; }

    }
}
