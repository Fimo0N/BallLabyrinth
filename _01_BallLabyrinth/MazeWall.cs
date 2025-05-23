
using System;


public class MazeWall
{
    public bool BlockedUp { get; }
    public bool BlockedDown { get; }
    public bool BlockedLeft { get; }
    public bool BlockedRight { get; }

   
    public MazeWall(bool blockedUp, bool blockedDown, bool blockedLeft, bool blockedRight)
    {
        BlockedUp = blockedUp;
        BlockedDown = blockedDown;
        BlockedLeft = blockedLeft;
        BlockedRight = blockedRight;
    }

    
    public static MazeWall[,] CreateMazeGrid()
    {
        
        MazeWall[,] grid = new MazeWall[7, 7];

       
        // Row 1
        grid[0, 0] = new MazeWall(true, false, true, true); // (1,1): Blocked Up, Left, Right
        grid[0, 1] = new MazeWall(true, false, true, false); // (1,2): Blocked Up, Left
        grid[0, 2] = new MazeWall(true, true, false, false); // (1,3): Blocked Up, Down
        grid[0, 3] = new MazeWall(true, false, false, true); // (1,4): Blocked Up, Right
        grid[0, 4] = new MazeWall(true, false, true, false); // (1,5): Blocked Up, Left
        grid[0, 5] = new MazeWall(true, false, false, false); // (1,6): Blocked Up
        grid[0, 6] = new MazeWall(true, true, false, true); // (1,7): Blocked Down, Right, Up

        // Row 2
        grid[1, 0] = new MazeWall(false, false, true, false); // (2,1): Blocked Left
        grid[1, 1] = new MazeWall(false, false, false, false); // (2,2): Blocked -
        grid[1, 2] = new MazeWall(true, false, false, false); // (2,3): Blocked Up
        grid[1, 3] = new MazeWall(false, false, false, false); // (2,4): Blocked -
        grid[1, 4] = new MazeWall(false, false, false, false); // (2,5): Blocked -
        grid[1, 5] = new MazeWall(false, false, false, false); // (2,6): Blocked -
        grid[1, 6] = new MazeWall(true, false, false, true); // (2,7): Blocked Right, Up

        // Row 3
        grid[2, 0] = new MazeWall(false, false, true, false); // (3,1): Blocked Left
        grid[2, 1] = new MazeWall(false, true, false, false); // (3,2): Blocked Down
        grid[2, 2] = new MazeWall(false, false, false, true); // (3,3): Blocked Right
        grid[2, 3] = new MazeWall(false, false, true, false); // (3,4): Blocked Left
        grid[2, 4] = new MazeWall(false, false, false, false); // (3,5): Blocked -
        grid[2, 5] = new MazeWall(false, false, false, true); // (3,6): Blocked Right
        grid[2, 6] = new MazeWall(false, false, true, true); // (3,7): Blocked Left

        // Row 4
        grid[3, 0] = new MazeWall(false, false, true, false); // (4,1): Blocked Left
        grid[3, 1] = new MazeWall(true, false, false, false); // (4,2): Blocked Up
        grid[3, 2] = new MazeWall(false, false, false, false); // (4,3): Blocked -
        grid[3, 3] = new MazeWall(false, true, false, true); // (4,4): Blocked Down, Right
        grid[3, 4] = new MazeWall(false, false, true, true); // (4,5): Blocked Left, Right
        grid[3, 5] = new MazeWall(false, false, true, false); // (4,6): Blocked Left
        grid[3, 6] = new MazeWall(false, true, false, true); // (4,7): Blocked Right, Down

        // Row 5
        grid[4, 0] = new MazeWall(false, true, true, false); // (5,1): Blocked Down, Left
        grid[4, 1] = new MazeWall(false, false, false, false); // (5,2): Blocked -
        grid[4, 2] = new MazeWall(false, false, false, false); // (5,3): Blocked -
        grid[4, 3] = new MazeWall(true, false, false, false); // (5,4): Blocked Up
        grid[4, 4] = new MazeWall(false, true, false, false); // (5,5): Blocked Down
        grid[4, 5] = new MazeWall(false, false, false, false); // (5,6): Blocked -
        grid[4, 6] = new MazeWall(true, false, false, true); // (5,7): Blocked Right, Up

        // Row 6
        grid[5, 0] = new MazeWall(true, false, true, false); // (6,1): Blocked Up, Left
        grid[5, 1] = new MazeWall(false, false, false, true); // (6,2): Right
        grid[5, 2] = new MazeWall(false, true, true, true); // (6,3): Blocked Left, Right, Down - Goal State
        grid[5, 3] = new MazeWall(false, false, true, false); // (6,4): Blocked Left
        grid[5, 4] = new MazeWall(true, false, false, false); // (6,5): Up
        grid[5, 5] = new MazeWall(false, false, false, false); // (6,6): -
        grid[5, 6] = new MazeWall(false, false, false, true); // (6,7): Blocked Right

        // Row 7
        grid[6, 0] = new MazeWall(false, true, true, false); // (7,1): Blocked Left, Down
        grid[6, 1] = new MazeWall(false, true, false, false); // (7,2): Blocked Down
        grid[6, 2] = new MazeWall(true, true, false, false); // (7,3): Blocked Down, Up
        grid[6, 3] = new MazeWall(false, true, false, true); // (7,4): Blocked Down, Right
        grid[6, 4] = new MazeWall(false, true, true, false); // (7,5): Blocked Down, Left
        grid[6, 5] = new MazeWall(false, true, false, true); // (7,6): Blocked Down, Right
        grid[6, 6] = new MazeWall(false, true, true, true); // (7,7): Blocked Left, Down, Right

        return grid;
    }
}
