using System;
using AdventureGame.Core;

class Program
{
	static void Main()
	{
        
        GameEngine engine = new GameEngine(10, 10);

		while (engine.Player.IsAlive)
		{
			Console.Clear();
            /// <summary>
			/// Initilz the maze and display it on the console. 
			/// Each tile type is represented by a different symbol: 
			/// @ for the player, 
			/// # for walls, 
			/// M for monsters, 
			/// W for weapons, 
			/// P for potions, 
			/// E for the exit, and . for empty spaces.
			/// </summary>

            for (int y = 0; y < engine.Maze.Height; y++)
			{
				for (int x = 0; x < engine.Maze.Width; x++)
				{
					var tile = engine.Maze.Grid[x, y];
					char symbol = tile.Type switch
					{
						TitleType.Player => '@',
						TitleType.Wall => '#',
						TitleType.Monster => 'M',
						TitleType.Weapon => 'W',
						TitleType.Potion => 'P',
						TitleType.Exit => 'E',
						_ => '.'
					};
					Console.Write(symbol + " ");
				}
				Console.WriteLine();
			}

			Console.WriteLine($"\nYour HP: {engine.Player.Health}");
			Console.WriteLine("Move with W/A/S/D");

            /// <summary>
			/// waiting for the users input for W/A/S/D
			/// </summary>
            var key = Console.ReadKey(true).Key;
			string result = engine.MovePlayer(key);
			Console.WriteLine(result);

			if (result.Contains("won") || result.Contains("Game Over"))
				break;
		}

		Console.WriteLine("Press any key to exit...");
		Console.ReadKey();
	}
}
