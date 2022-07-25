using CreatureWars.Declarations;


namespace CreatureWars.Class
{
    class ItemBase : GameObject, INameble
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ProgramName { get; set; }
        public Attributes Attributes { get; set; }
    }
}
