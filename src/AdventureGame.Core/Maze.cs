using System;

namespace AdventureGame.Core
{
    public class Maze
    {
        private static Random _random = new Random();

        /// <summary>
        /// Gets the width of the maze.
        /// </summary>
        /// <value>
        /// The number of horizontal cells in the maze.
        /// </value>
        public int Width { get; }

        /// <summary>
        /// Gets the height of the maze.
        /// </summary>
        /// <value>
        /// The number of vertical cells in the maze.
        /// </value>
        public int Height { get; }

        /// <summary>
        /// Gets the two-dimensional array representing the maze grid.
        /// </summary>
        /// <value>
        /// A <see cref="Tile"/>[,] array where each element represents a cell in the maze,
        /// containing information such as type, items, and monsters.
        /// </value>
        public Tile[,] Grid { get; }

        /// <summary>
        /// Gets the starting position of the player.
        /// </summary>
        /// <value>
        /// A tuple containing the X and Y coordinates of the player's starting position.
        /// </value>
        public (int X, int Y) PlayerStart { get; private set; }

        /// <summary>
        /// Gets the starting position of the exit.
        /// </summary>
        /// <value>
        /// A tuple containing the X and Y coordinates of the exit position.
        /// </value>
        public (int X, int Y) ExitPosition { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Maze"/> class with the specified dimensions.
        /// </summary>
        /// <param name="width">The number of horizontal cells in the maze.</param>
        /// <param name="height">The number of vertical cells in the maze.</param>
        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new Tile[width, height];

            GenerateMaze();
        }

        /// <summary>
        /// Populates the maze grid with walls, empty spaces, the player start, exit, 
        /// monsters, weapons, and potions.
        /// </summary>
        /// <remarks>
        /// This method performs the following steps:
        /// <list type="bullet">
        /// <item>Sets the outer edges of the maze as walls.</item>
        /// <item>Sets the inner cells as empty spaces.</item>
        /// <item>Places the player at <see cref="PlayerStart"/> and marks the tile.</item>
        /// <item>Places the exit at <see cref="ExitPosition"/> and marks the tile.</item>
        /// <item>Randomly adds additional walls inside the maze.</item>
        /// <item>Randomly populates monsters, weapons, and potions in empty cells.</item>
        /// </list>
        /// This method is called internally by the <see cref="Maze"/> constructor and should not
        /// be called externally.
        /// </remarks>
        private void GenerateMaze()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                        Grid[x, y] = new Tile(TitleType.Wall);
                    else
                        Grid[x, y] = new Tile(TitleType.Empty);
                }
            }

            PlayerStart = (1, 1);
            Grid[PlayerStart.X, PlayerStart.Y].Type = TitleType.Player;

            ExitPosition = (Width - 2, Height - 2);
            Grid[ExitPosition.X, ExitPosition.Y].Type = TitleType.Exit;

            for (int i = 0; i < (Width * Height) / 5; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if ((x, y) != PlayerStart && (x, y) != ExitPosition)
                    Grid[x, y].Type = TitleType.Wall;
            }

            for (int i = 0; i < (Width * Height) / 10; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if (Grid[x, y].Type == TitleType.Empty)
                {
                    Grid[x, y].Type = TitleType.Monster;
                    Grid[x, y].Monster = new Monster();
                }
            }

            for (int i = 0; i < (Width * Height) / 15; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if (Grid[x, y].Type == TitleType.Empty)
                {
                    var weapon = new Weapon("Sword", _random.Next(1, 6));
                    Grid[x, y].Type = TitleType.Weapon;
                    Grid[x, y].Item = weapon;
                }
            }

            for (int i = 0; i < (Width * Height) / 15; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if (Grid[x, y].Type == TitleType.Empty)
                {
                    var potion = new Potion("Health Potion", 20);
                    Grid[x, y].Type = TitleType.Potion;
                    Grid[x, y].Item = potion;
                }
            }
        }
    }
}
