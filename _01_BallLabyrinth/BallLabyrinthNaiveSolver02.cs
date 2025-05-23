using _01_BallLabyrinth;

public class BallLabyrinthNaiveSolver02 : BaseOfGraphSearchAlgorithms
{
    private Random random = new Random();

    public BallLabyrinthNaiveSolver02(BallLabyrinthState initialState, int depthLimitPerTrial = 50, int maxTrials = 1000) : base(initialState)
    {
        this.depthLimitPerTrial = depthLimitPerTrial;
        this.maxTrials = maxTrials;
    }

    private int depthLimitPerTrial; //Don't go deeper than X steps in a single random walk.

    private int maxTrials;  //Try Y different random paths before giving up.
    public override List<BallLabyrinthState> Solve()
    {
        Console.WriteLine($"Starting Depth-Bound Trial-Error Solver with Depth Limit per Trial: {depthLimitPerTrial}, Max Trials: {maxTrials}");

        for (int trial = 1; trial <= maxTrials; trial++)
        {
            Console.WriteLine($"\nTrial {trial}: Starting new random walk from {InitialState}");

            BallLabyrinthState currentState = InitialState;
            List<BallLabyrinthState> currentPathStates = new List<BallLabyrinthState>();
            currentPathStates.Add(currentState);

            int currentDepth = 0;

            
            while (!currentState.IsGoalState() && currentDepth < depthLimitPerTrial)
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
                        
                        currentState = nextState;
                       
                        currentPathStates.Add(currentState);
                        moved = true;
                        currentDepth++; 
                        
                        break;
                    }
                }

              
                if (!moved)
                {
                    Console.WriteLine($"Trial {trial}: Solver got stuck at {currentState} (no valid moves). Ending trial.");
                 
                    break;
                }
            }

           
            if (currentState.IsGoalState())
            {
                Console.WriteLine($"Trial {trial}: Goal reached at {currentState} in {currentDepth} steps.");
                return currentPathStates;
            }
            else
            {
                
                Console.WriteLine($"Trial {trial}: Depth limit ({depthLimitPerTrial}) reached. Goal not found in this trial.");
            }
        }

        
        Console.WriteLine($"\nMaximum number of trials ({maxTrials}) reached. Goal not found.");
        return null;
    }
}