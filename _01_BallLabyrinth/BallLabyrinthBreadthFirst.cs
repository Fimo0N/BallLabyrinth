using _01_BallLabyrinth;
using System;
using System.Collections.Generic;
using System.Linq;

public class BallLabyrinthBreadthFirst : BaseOfGraphSearchAlgorithms
{
    private HashSet<BallLabyrinthState> visitedStates;

    public BallLabyrinthBreadthFirst(BallLabyrinthState initialState) : base(initialState)
    {
        this.visitedStates = new HashSet<BallLabyrinthState>();
    }

    public override List<BallLabyrinthState> Solve()
    {
        Console.WriteLine("Starting Breadth-First Search Solver");
        visitedStates.Clear();

        Queue<BallLabyrinthNode> queue = new Queue<BallLabyrinthNode>(); //First in First out processing

        BallLabyrinthNode initialNode = new BallLabyrinthNode(InitialState);
        queue.Enqueue(initialNode);

        visitedStates.Add(InitialState);

        while (queue.Count > 0)
        {
            BallLabyrinthNode currentNode = queue.Dequeue();
            BallLabyrinthState currentState = currentNode.State;
            //Constructs and returns the path from the initial state to the goal by backtracking through parent nodes.
            if (currentState.IsGoalState())
            {
                Console.WriteLine($"Goal reached at {currentState} in {currentNode.Depth} steps (Shortest Path Found).");
                List<BallLabyrinthState> solutionStates = new List<BallLabyrinthState>();
                BallLabyrinthNode node = currentNode;
                while (node != null)
                {
                    solutionStates.Add(node.State);
                    node = node.Parent; 
                }
                solutionStates.Reverse(); 
                return solutionStates; 
            }
            // Continues exploring other states from the queue.
            Direction[] possibleDirections = (Direction[])Enum.GetValues(typeof(Direction));

            foreach (Direction direction in possibleDirections)
            {
                BallLabyrinthState nextState = currentState.Move(direction);

                if (!nextState.Equals(currentState) && !visitedStates.Contains(nextState))
                {

                    BallLabyrinthNode nextNode = new BallLabyrinthNode(nextState, currentNode, direction, currentNode.Cost + 1);


                    visitedStates.Add(nextState);

                    queue.Enqueue(nextNode);
                }
            }
        }

        Console.WriteLine("Breadth-First Search finished. No solution found.");
        return null; 
    }
}