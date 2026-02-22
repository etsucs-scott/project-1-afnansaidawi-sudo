namespace AdventureGame.Core
{
    public enum TitleType
    {
        Empty,
        Wall,
        Player,
        Monster,
        Weapon,
        Potion,
        Exit
    }

    public class Tile
    {
        public TitleType Type { get; set; }
        public Item? Item { get; set; }
        public Monster? Monster { get; set; }

        public Tile(TitleType type)
        {
            Type = type;
        }
    }
}
