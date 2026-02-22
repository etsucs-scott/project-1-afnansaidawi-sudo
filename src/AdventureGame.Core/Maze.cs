using System;

namespace AdventureGame.Core
{
    public class Maze
    {
        private static Random _random = new Random();

        public int Width { get; }
        public int Height { get; }
        public Tile[,] Grid { get; }

        public (int X, int Y) PlayerStart { get; private set; }
        public (int X, int Y) ExitPosition { get; private set; }

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            Grid = new Tile[width, height];

            GenerateMaze();
        }

        private void GenerateMaze()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (x == 0 || y == 0 || x == Width - 1 || y == Height - 1)
                        Grid[x, y] = new Tile(TileType.Wall);
                    else
                        Grid[x, y] = new Tile(TileType.Empty);
                }
            }

            PlayerStart = (1, 1);
            Grid[PlayerStart.X, PlayerStart.Y].Type = TileType.Player;

            ExitPosition = (Width - 2, Height - 2);
            Grid[ExitPosition.X, ExitPosition.Y].Type = TileType.Exit;

            for (int i = 0; i < (Width * Height) / 5; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if ((x, y) != PlayerStart && (x, y) != ExitPosition)
                    Grid[x, y].Type = TileType.Wall;
            }

            for (int i = 0; i < (Width * Height) / 10; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if (Grid[x, y].Type == TileType.Empty)
                {
                    Grid[x, y].Type = TileType.Monster;
                    Grid[x, y].Monster = new Monster();
                }
            }

            for (int i = 0; i < (Width * Height) / 15; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if (Grid[x, y].Type == TileType.Empty)
                {
                    var weapon = new Weapon("Sword", _random.Next(1, 6));
                    Grid[x, y].Type = TileType.Weapon;
                    Grid[x, y].Item = weapon;
                }
            }

            for (int i = 0; i < (Width * Height) / 15; i++)
            {
                int x = _random.Next(1, Width - 1);
                int y = _random.Next(1, Height - 1);

                if (Grid[x, y].Type == TileType.Empty)
                {
                    var potion = new Potion("Health Potion", 20);
                    Grid[x, y].Type = TileType.Potion;
                    Grid[x, y].Item = potion;
                }
            }
        }
    }
}
