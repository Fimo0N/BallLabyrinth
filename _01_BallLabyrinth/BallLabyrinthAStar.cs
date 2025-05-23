using _01_BallLabyrinth;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

public class BallLabyrinthAStar : BaseOfGraphSearchAlgorithms
{
    private Dictionary<BallLabyrinthState, double> gScore; //Actual cost from start to a state
    private Dictionary<BallLabyrinthState, double> fScore; //Estimated cost to goal
    private Dictionary<BallLabyrinthState, BallLabyrinthNode> cameFrom;

    public BallLabyrinthAStar(BallLabyrinthState initialState) : base(initialState)
    {
        gScore = new Dictionary<BallLabyrinthState, double>();
        fScore = new Dictionary<BallLabyrinthState, double>();
        cameFrom = new Dictionary<BallLabyrinthState, BallLabyrinthNode>();
    }

    public override List<BallLabyrinthState> Solve()
    {
        Console.WriteLine("Starting A* Search Solver");

        SortedList<double, List<BallLabyrinthNode>> openSet = new SortedList<double, List<BallLabyrinthNode>>(); 
        //States to explore, sorted by lowest fScore

        BallLabyrinthNode initialNode = new BallLabyrinthNode(InitialState);

        double initialFScore = CalculateHeuristic(InitialState);
        if (!openSet.ContainsKey(initialFScore))
        {
            openSet.Add(initialFScore, new List<BallLabyrinthNode>());
        }
        openSet[initialFScore].Add(initialNode);
        gScore[InitialState] = 0;
        fScore[InitialState] = initialFScore;
        //Get node with lowest fScore
        while (openSet.Count > 0)
        {
            
            double currentFScore = openSet.Keys[0];
           
            List<BallLabyrinthNode> nodesWithSameFScore = openSet[currentFScore];
         
            BallLabyrinthNode currentNode = nodesWithSameFScore[0];
            BallLabyrinthState currentState = currentNode.State;

       
            nodesWithSameFScore.RemoveAt(0);
            if (nodesWithSameFScore.Count == 0)
            {
                openSet.RemoveAt(0);
            }

          
            if (currentState.IsGoalState())
            {
                Console.WriteLine($"Goal reached at {currentState} in {currentNode.Depth} steps.");

                List<BallLabyrinthState> solutionStates = new List<BallLabyrinthState>();
                BallLabyrinthState state = currentState;
  
                while (cameFrom.ContainsKey(state))
                {
                    solutionStates.Add(state);
                    BallLabyrinthNode parentNode = cameFrom[state];
                    state = parentNode.State; 
                }
                solutionStates.Add(InitialState); 
                solutionStates.Reverse(); 
                return solutionStates; 
            }

           
            Direction[] possibleDirections = (Direction[])Enum.GetValues(typeof(Direction));

            foreach (Direction direction in possibleDirections)
            {
                
                BallLabyrinthState nextState = currentState.Move(direction);

                if (!nextState.Equals(currentState))
                {
                   
                    double tentativeGScore = gScore.ContainsKey(currentState) ? gScore[currentState] + 1 : 1;
                    //Only consider new or better paths
                    if (!gScore.ContainsKey(nextState) || tentativeGScore < gScore[nextState])
                    {
       
                        cameFrom[nextState] = currentNode; // Store the parent node
                        gScore[nextState] = tentativeGScore;
                        fScore[nextState] = tentativeGScore + CalculateHeuristic(nextState);

                        BallLabyrinthNode nextNode = new BallLabyrinthNode(nextState, currentNode, direction, tentativeGScore);

                        double nextFScore = fScore[nextState];
                        if (!openSet.ContainsKey(nextFScore))
                        {
                            openSet.Add(nextFScore, new List<BallLabyrinthNode>());
                        }
                        openSet[nextFScore].Add(nextNode);
                    }
                }
            }
        }

        Console.WriteLine("A* Search finished. No solution found.");
        return null; // Return null if no solution is found.
    }

    private double CalculateHeuristic(BallLabyrinthState state)
    {
        int goalRow = 5;
        int goalColumn = 2;
        return Math.Abs(state.Row - goalRow) + Math.Abs(state.Column - goalColumn);
    }
}