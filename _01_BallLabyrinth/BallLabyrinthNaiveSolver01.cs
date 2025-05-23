using _01_BallLabyrinth;
using System;
using System.Collections.Generic;
using System.Linq;

public class BallLabyrinthNaiveSolver01 : BaseOfGraphSearchAlgorithms
{
    private Random random = new Random();
    public BallLabyrinthNaiveSolver01(BallLabyrinthState initialState) : base(initialState)
    {
    }

    public override List<BallLabyrinthState> Solve()
    {
        Console.WriteLine("Starting Naive Random Walk Solver (Limited Steps)");

        BallLabyrinthState currentState = InitialState;
        List<BallLabyrinthState> pathStates = new List<BallLabyrinthState>();
        pathStates.Add(currentState);

        int maxSteps = 10000; // You can adjust this limit as needed.
        int steps = 0;

        while (!currentState.IsGoalState() && steps < maxSteps)
        {
            // Get all possible directions.
            Direction[] possibleDirections = (Direction[])Enum.GetValues(typeof(Direction));

            // Shuffle the directions randomly.
            possibleDirections = possibleDirections.OrderBy(_ => random.Next()).ToArray();

            bool moved = false;
            foreach (Direction direction in possibleDirections)
            {
        
                BallLabyrinthState nextState = currentState.Move(direction);

         
                if (!nextState.Equals(currentState))
                {
                    // Move to the next state.
                    currentState = nextState;
                    // Add the new state to the path of states.
                    pathStates.Add(currentState);
                    moved = true;
                    steps++;
                    break; 
                }
            }

       
            if (!moved)
            {
                Console.WriteLine("Solver got stuck (no valid moves from current state).");
            
                return null;
            }
        }

        if (currentState.IsGoalState())
        {
            Console.WriteLine($"Goal reached in {steps} steps.");
            return pathStates;
        }
        else
        {
            Console.WriteLine($"Goal not reached within the step limit of {maxSteps}.");
            return null;
        }
    }
}
