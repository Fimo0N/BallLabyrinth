using _01_BallLabyrinth;
using System;
using System.Collections.Generic;
using System.Linq;


public class BallLabyrinthBackTrack : BaseOfGraphSearchAlgorithms
{
    private HashSet<BallLabyrinthState> visitedStates; // Keeps track of already visited states to avoid cycles
    private int depthLimit;

    
    public BallLabyrinthBackTrack(BallLabyrinthState initialState, int depthLimit = 100) : base(initialState)
    {
        this.depthLimit = depthLimit;
       
        this.visitedStates = new HashSet<BallLabyrinthState>();
    }

    public override List<BallLabyrinthState> Solve()
    {
        Console.WriteLine($"Starting Backtracking Solver with Depth Limit: {depthLimit}");
        visitedStates.Clear();

        List<BallLabyrinthState> initialPathStates = new List<BallLabyrinthState> { InitialState };
        return Backtrack(InitialState, initialPathStates, 0);
    }

    private List<BallLabyrinthState> Backtrack(BallLabyrinthState currentState, List<BallLabyrinthState> currentPathStates, int currentDepth)
    {
        if (currentState.IsGoalState())
        {
            Console.WriteLine($"Goal reached at {currentState} in {currentDepth} steps.");
            return currentPathStates;
        }

        
        if (currentDepth >= depthLimit)
        {
            return null;
        }

        visitedStates.Add(currentState);

        Direction[] possibleDirections = (Direction[])Enum.GetValues(typeof(Direction));

        //explore each direction
        foreach (Direction direction in possibleDirections)
        {
            BallLabyrinthState nextState = currentState.Move(direction);

            //Different and not yet visited
            if (!nextState.Equals(currentState) && !visitedStates.Contains(nextState))
            {
                List<BallLabyrinthState> newPathStates = new List<BallLabyrinthState>(currentPathStates);
                newPathStates.Add(nextState);

                List<BallLabyrinthState> resultPath = Backtrack(nextState, newPathStates, currentDepth + 1);

                if (resultPath != null)
                {
                    return resultPath; //If a valid path is found below, return it.
                }
            }
        }
        //Allows the state to be revisited from a different path.
        visitedStates.Remove(currentState);

        return null; 
    }
}