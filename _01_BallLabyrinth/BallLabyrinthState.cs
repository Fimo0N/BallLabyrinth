
using System;
using _01_BallLabyrinth;
public class BallLabyrinthState
{
   
    public int Row { get; }
    public int Column { get; }

   
    private static readonly MazeWall[,] mazeGrid = MazeWall.CreateMazeGrid();
    private const int GridSize = 7; 

    public BallLabyrinthState(int row, int column)
    {
        
        if (row < 0 || row >= GridSize || column < 0 || column >= GridSize)
        {
            throw new ArgumentOutOfRangeException("Initial ball position is outside the grid.");
        }
        Row = row;
        Column = column;
    }

    public bool IsGoalState()
    {
        return Row == 5 && Column == 2;
    }

    public BallLabyrinthState Move(Direction direction)
    {
        int nextRow = Row;
        int nextColumn = Column;

        while (true)
        {
            int currentRow = nextRow;
            int currentColumn = nextColumn;

       
            MazeWall currentCellWalls = mazeGrid[currentRow, currentColumn];

            switch (direction)
            {
                case Direction.Up:
                    // If there's a wall above, stop.
                    if (currentCellWalls.BlockedUp) return new BallLabyrinthState(currentRow, currentColumn);
                    // Move up if not at the top edge.
                    if (nextRow > 0) nextRow--;
                    else return new BallLabyrinthState(currentRow, currentColumn); 
                    break;
                case Direction.Down:
                    // If there's a wall below, stop.
                    if (currentCellWalls.BlockedDown) return new BallLabyrinthState(currentRow, currentColumn);
                    // Move down if not at the bottom edge.
                    if (nextRow < GridSize - 1) nextRow++;
                    else return new BallLabyrinthState(currentRow, currentColumn); 
                    break;
                case Direction.Left:
                    // If there's a wall to the left, stop.
                    if (currentCellWalls.BlockedLeft) return new BallLabyrinthState(currentRow, currentColumn);
                    // Move left if not at the left edge.
                    if (nextColumn > 0) nextColumn--;
                    else return new BallLabyrinthState(currentRow, currentColumn); 
                    break;
                case Direction.Right:
                    // If there's a wall to the right, stop.
                    if (currentCellWalls.BlockedRight) return new BallLabyrinthState(currentRow, currentColumn);
                    // Move right if not at the right edge.
                    if (nextColumn < GridSize - 1) nextColumn++;
                    else return new BallLabyrinthState(currentRow, currentColumn); 
                    break;
            }

            
            if (nextRow == currentRow && nextColumn == currentColumn)
            {
                return new BallLabyrinthState(currentRow, currentColumn);
            }
        }
    }

   
    public override bool Equals(object obj)
    {
        if (obj is BallLabyrinthState other)
        {
            return Row == other.Row && Column == other.Column;
        }
        return false;
    }


    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }

    public override string ToString()
    {
        return $"({Row + 1},{Column + 1})"; // Return 1-indexed for readability
    }
}