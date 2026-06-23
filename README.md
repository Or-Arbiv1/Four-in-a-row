# Four in a Row

A classic **Connect Four** game built with C# and Windows Forms. Drop chips
into a grid and be the first to line up four in a row — horizontally,
vertically, or diagonally. Play against a friend or against the computer.

## Features

- **Two game modes** — player vs. player, or player vs. computer.
- **Configurable board** — choose the number of rows and columns before
  starting a match.
- **Score tracking** — wins are tallied across rounds.
- **Clean separation of concerns** — game rules live in a standalone logic
  library, independent of the UI.

## Tech Stack

- C# / .NET Framework 4.8
- Windows Forms (WinForms)

## Project Structure

| Project | Description |
| ------- | ----------- |
| `Logic` | Core game engine — board, chips, players, and game flow. UI-agnostic. |
| `UI`    | Windows Forms front end — settings screen and the game board window. |

Key types:

- `Logic/Game.cs` — orchestrates turns, win detection, and scoring.
- `Logic/Board.cs` — the grid and its state.
- `Logic/Player.cs` — player state and the computer's move-selection logic.
- `Logic/Chip.cs` — a single cell/chip.
- `UI/GameSettings.cs` — pre-game setup (names, board size, opponent type).
- `UI/GameWindow.cs` — the interactive game board.

## Getting Started

1. Open `Four in a row.sln` in Visual Studio (2019 or later).
2. Set **UI** as the startup project.
3. Build and run (`F5`).

On launch you'll configure the players and board size, then play.

## How to Play

Click a column to drop your chip into it. Chips fall to the lowest empty cell.
The first player to connect four of their chips in a line — across, down, or
diagonally — wins the round. If the board fills with no winner, the round is a
draw.
