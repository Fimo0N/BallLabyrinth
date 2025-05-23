
using _01_BallLabyrinth;
using System;
using System.Collections.Generic;

public class BallLabyrinthNode
{
    public BallLabyrinthState State { get; }

    public BallLabyrinthNode Parent { get; }

    public Direction? Action { get; }

    public int Depth { get; }

    public double Cost { get; }

    public BallLabyrinthNode(BallLabyrinthState initialState)
    {
        State = initialState;
        Parent = null;
        Action = null;
        Depth = 0;
        Cost = 0; // Cost to reach the start node is 0.
    }

    public BallLabyrinthNode(BallLabyrinthState state, BallLabyrinthNode parent, Direction action, double cost)
    {
        State = state;
        Parent = parent;
        Action = action;
        Depth = parent.Depth + 1;
        Cost = parent.Cost+cost;
    }

    public List<Direction> GetPath()
    {
        List<Direction> path = new List<Direction>();
        BallLabyrinthNode currentNode = this;

        while (currentNode.Parent != null)
        {
            path.Add(currentNode.Action.Value);
            currentNode = currentNode.Parent;
        }

        path.Reverse();
        return path;
    }

    public override string ToString()
    {
        return State.ToString();
    }
}
