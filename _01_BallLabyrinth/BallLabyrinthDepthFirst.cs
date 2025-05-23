using _01_BallLabyrinth;
using System;
using System.Collections.Generic;
using System.Linq;

public class BallLabyrinthDepthFirst : BaseOfGraphSearchAlgorithms
{
    private HashSet<BallLabyrinthState> visitedStates;

    public BallLabyrinthDepthFirst(BallLabyrinthState initialState) : base(initialState)
    {
        this.visitedStates = new HashSet<BallLabyrinthState>();
    }

    public override List<BallLabyrinthState> Solve()
    {
        Console.WriteLine("Starting Depth-First Search Solver");
        visitedStates.Clear();

        Stack<BallLabyrinthNode> stack = new Stack<BallLabyrinthNode>();

        BallLabyrinthNode initialNode = new BallLabyrinthNode(InitialState);
        stack.Push(initialNode);

        while (stack.Count > 0)  //Runs until no more nodes are left to explore.
        {
            BallLabyrinthNode currentNode = stack.Pop();
            BallLabyrinthState currentState = currentNode.State;

            if (visitedStates.Contains(currentState))
            {
                continue;
            }

            visitedStates.Add(currentState);

            if (currentState.IsGoalState())
            {
                Console.WriteLine($"Goal reached at {currentState} in {currentNode.Depth} steps.");

                List<BallLabyrinthState> solutionStates = new List<BallLabyrinthState>();
                BallLabyrinthNode node = currentNode;
                while (node != null)
                {
                    solutionStates.Add(node.State);  //Walks backward from the goal using .Parent pointers.
                    node = node.Parent; 
                }
                solutionStates.Reverse();  //Then reverses the list to make it start-to-goal.
                return solutionStates; 
            }

            Direction[] possibleDirections = (Direction[])Enum.GetValues(typeof(Direction));

            Array.Reverse(possibleDirections); 

            foreach (Direction direction in possibleDirections)
            {
                BallLabyrinthState nextState = currentState.Move(direction);
                if (!nextState.Equals(currentState) && !visitedStates.Contains(nextState))
                {

                    BallLabyrinthNode nextNode = new BallLabyrinthNode(nextState, currentNode, direction, currentNode.Cost + 1);

                    stack.Push(nextNode);
                }
            }
        }

        Console.WriteLine("Depth-First Search finished. No solution found.");
        return null; 
    }
}