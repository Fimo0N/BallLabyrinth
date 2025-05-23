
# Ball Labyrinth Solver Visualization

This repository contains a C# Windows Forms application that visualizes different search algorithms solving the "Ball Labyrinth" puzzle. The application allows users to select various search algorithms and observe their step-by-step execution to find a path from a starting point to a goal within a predefined maze.

## Project Description

The Ball Labyrinth is a classic search problem where a ball navigates a grid-based maze. The ball moves continuously in a chosen direction (Up, Down, Left, Right) until it hits a wall or the maze boundary. The objective is to find a sequence of moves (a path) that takes the ball from a specified initial position to a target goal position.

This application provides a graphical interface to:

- Display the maze structure.
- Visualize the ball's movement along a solution path.
- Compare the behavior and performance of different search algorithms.
- Pre-compute solutions for all algorithms on form load for instant switching between visualizations (for reasonable maze sizes).

## Features

- **Interactive Visualization:** See the ball move through the labyrinth step-by-step.
- **Algorithm Selection:** Choose from a variety of search algorithms via a dropdown menu.
- **Path Navigation:** Use "Previous" and "Next" buttons to traverse the solution path.
- **Real-time Status:** View the current algorithm's status, ball position, and step information.
- **Pre-computed Solutions:** Solutions for all algorithms are pre-computed on form load for instant switching between visualizations (for reasonable maze sizes).

## Implemented Algorithms

The project includes implementations of the following search algorithms:

### Breadth-First Search (BFS):

- Guaranteed to find the shortest path in terms of number of moves.
- Explores the maze level by level.

### Depth-First Search (DFS):

- Explores as deeply as possible along each branch before backtracking.
- Not guaranteed to find the shortest path.

### A* Search:

- An informed search algorithm that uses a heuristic function to guide its search.
- Uses Manhattan distance as its heuristic to estimate the distance to the goal.
- Guaranteed to find the shortest path if the heuristic is admissible.

### Backtracking Search:

- A recursive depth-first search that systematically tries to build a solution.
- Includes a depth limit to prevent infinite recursion or excessively long searches.

### Naive Random Walk (Limited):

- A simple, uninformed approach that randomly chooses a valid direction at each step.
- Includes a step limit to prevent indefinite execution.
- Not guaranteed to find a solution or the shortest path.

### Depth-Bound Trial-Error (Random Walk with Restarts):

- Performs multiple random walks, each limited by a certain depth. If a trial fails, it restarts from the initial state.
- Better chance of finding a solution than a single random walk, but still not guaranteed optimality or completeness.

## Maze Structure

- The labyrinth is a 7x7 grid.
- The wall configurations are hardcoded within the `MazeWall.cs` class.
- Initial Position: (1,4) (1-indexed, corresponding to (0,3) in 0-indexed coordinates).
- Goal Position: (6,3) (1-indexed, corresponding to (5,2) in 0-indexed coordinates).

## How to Run

Clone the repository:

```bash
git clone <repository_url>
```

Open in Visual Studio:

- Open the `.sln` (solution) file in Visual Studio.

Build the Project:

- Go to **Build > Build Solution** (or press `Ctrl+Shift+B`).

Run the Application:

- Start the application (press `F5` or click the Start button in Visual Studio).
- The application window will appear, and it will begin pre-computing solutions for all algorithms.
- Once complete, you can select an algorithm from the dropdown and navigate through its solution path.
