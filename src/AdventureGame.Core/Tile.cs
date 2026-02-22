namespace AdventureGame.Core
{
    public enum TileType
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
        public TileType Type { get; set; }
        public Item? Item { get; set; }
        public Monster? Monster { get; set; }

        public Tile(TileType type)
        {
            Type = type;
        }
    }
}
