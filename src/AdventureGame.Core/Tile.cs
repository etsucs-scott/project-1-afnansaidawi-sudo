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
        /// <summary>
        /// Gets or sets the type of the tile.
        /// </summary>
        public TitleType Type { get; set; }


        /// <summary>
        /// Gets or sets the item on the tile, if any.
        /// </summary>
        public Item? Item { get; set; }

        /// <summary>
        /// Gets or sets the monster on the tile, if any.
        /// </summary>
        public Monster? Monster { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Tile"/> class with the specified type.
        /// </summary>
        /// <param name="type">The type of the tile.</param>
        public Tile(TitleType type)
        {
            Type = type;
        }
    }
}
