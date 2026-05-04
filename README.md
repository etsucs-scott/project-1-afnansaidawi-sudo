# AdventureGame Console

## Build Instructions
```bash
dotnet build
```

## Run Instructions
```bash
dotnet run --project AdventureGame.Console
```

## Controls
WASD or Arrow Keys

## UML Class Diagram
```text
+-------------+     +------------+
|   Player    |     |    Maze    |
+-------------+     +------------+
| - health    |     | - grid[,]  |
| - position  |     +------------+
| +Move()     |     | +Generate()|
+-------------+     | +IsValid() |
       |                   ^
       | uses              |
       v                   |
+-------------+     +------------+
|  GameEngine |---->|    Item    |
+-------------+     +------------+
| +Run()      |     | - name     |
| +Update()   |     | +Use()     |
+-------------+     +------------+
```