using System;

namespace AdventureGame.Core
{
    public class GameEngine
    {
        /// <summary>
        /// Gets the maze associated with the game engine.
        /// </summary>
        /// <value>
        /// The <see cref="Maze"/> object that represents the current game map.
        /// </value>
        public Maze Maze { get; private set; }

        /// <summary>
        /// Gets the player instance associated with the game engine.
        /// </summary>
        /// <value>
        /// The <see cref="Player"/> object that represents the current player.
        /// </value>
        public Player Player { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameEngine"/> class
        /// with the specified maze dimensions.
        /// </summary>
        /// <param name="width">
        /// The width of the maze. Default value is 10.
        /// </param>
        /// <param name="height">
        /// The height of the maze. Default value is 10.
        /// </param>
        public GameEngine(int width = 10, int height = 10)
        {
            Maze = new Maze(width, height);
            Player = new Player();
            var start = Maze.PlayerStart;
            Maze.Grid[start.X, start.Y].Type = TitleType.Player;
        }

        /// <summary>
        /// Moves the player within the maze based on the pressed key.
        /// </summary>
        /// <param name="key">
        /// The <see cref="ConsoleKey"/> pressed by the user to control movement 
        /// (W = up, S = down, A = left, D = right).
        /// </param>
        /// <returns>
        /// A message describing the result of the move, such as successful movement,
        /// encountering a wall, picking up an item, battling a monster, reaching the exit,
        /// or an invalid action.
        /// </returns>
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

        /// <summary>
        /// Gets the current position of the player.
        /// </summary>
        /// <value>
        /// A tuple containing the X and Y coordinates of the player's current position.
        /// </value>
        /// <returns>
        /// the players current position
        /// </returns>
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

        /// <summary>
        /// Handles the combat sequence between the player and a monster.
        /// </summary>
        /// <param name="monster">
        /// The monster that the player is battling.
        /// </param>
        /// <returns>
        /// A string containing the full battle log, including damage dealt,
        /// remaining health, and the final outcome of the fight.
        /// </returns>
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
