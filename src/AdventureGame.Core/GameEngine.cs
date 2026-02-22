using System;

namespace AdventureGame.Core
{
    public class GameEngine
    {
        public Maze Maze { get; private set; }
        public Player Player { get; private set; }

        public GameEngine(int width = 10, int height = 10)
        {
            Maze = new Maze(width, height);
            Player = new Player();
            var start = Maze.PlayerStart;
            Maze.Grid[start.X, start.Y].Type = TitleType.Player;
        }

        public string MovePlayer(ConsoleKey key)
        {
            var currentPos = GetPlayerPosition();
            int newX = currentPos.X;
            int newY = currentPos.Y;

            switch (key)
            {
                case ConsoleKey.W: newY -= 1; break;
                case ConsoleKey.S: newY += 1; break;
                case ConsoleKey.A: newX -= 1; break;
                case ConsoleKey.D: newX += 1; break;
                default: return "Invalid key!";
            }

            if (newX < 0 || newX >= Maze.Width || newY < 0 || newY >= Maze.Height)
                return "Cannot move outside the maze!";
            if (Maze.Grid[newX, newY].Type == TitleType.Wall)
                return "There is a wall!";

            var tile = Maze.Grid[newX, newY];
            string message = "";

            switch (tile.Type)
            {
                case TitleType.Empty:
                    message = "Moved successfully.";
                    break;
                case TitleType.Weapon:
                    var weapon = tile.Item as Weapon;
                    if (weapon != null)
                    {
                        Player.Inventory.Add(weapon);
                        message = weapon.PickupMessage;
                    }
                    break;
                case TitleType.Potion:
                    var potion = tile.Item as Potion;
                    if (potion != null)
                    {
                        Player.Heal(potion.HealAmount);
                        message = potion.PickupMessage;
                    }
                    break;
                case TitleType.Monster:
                    if (tile.Monster != null)
                        message = Battle(tile.Monster);
                    break;
                case TitleType.Exit:
                    message = "You reached the exit! You won!";
                    break;
            }

            Maze.Grid[currentPos.X, currentPos.Y].Type = TitleType.Empty;
            Maze.Grid[newX, newY].Type = TitleType.Player;

            return message;
        }

        private (int X, int Y) GetPlayerPosition()
        {
            for (int x = 0; x < Maze.Width; x++)
            {
                for (int y = 0; y < Maze.Height; y++)
                {
                    if (Maze.Grid[x, y].Type == TitleType.Player)
                        return (x, y);
                }
            }
            return Maze.PlayerStart;
        }

        private string Battle(Monster monster)
        {
            string battleLog = "";
            while (Player.IsAlive && monster.IsAlive)
            {
                monster.TakeDamage(Player.Attack());
                battleLog += $"You hit the monster! Monster HP: {monster.Health}\n";

                if (!monster.IsAlive)
                {
                    battleLog += "Monster defeated!\n";
                    break;
                }

                Player.TakeDamage(monster.Attack());
                battleLog += $"Monster attacks! Your HP: {Player.Health}\n";

                if (!Player.IsAlive)
                {
                    battleLog += "You died! Game Over!\n";
                    break;
                }
            }

            var pos = GetPlayerPosition();
            Maze.Grid[pos.X, pos.Y].Monster = null;
            Maze.Grid[pos.X, pos.Y].Type = TitleType.Empty;

            return battleLog;
        }
    }
}
