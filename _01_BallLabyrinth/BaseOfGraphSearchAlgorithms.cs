
using _01_BallLabyrinth;
using System;
using System.Collections.Generic;

public abstract class BaseOfGraphSearchAlgorithms
{
    protected BallLabyrinthState InitialState { get; }

    public BaseOfGraphSearchAlgorithms(BallLabyrinthState initialState)
    {
        InitialState = initialState;
    }
    public abstract List<BallLabyrinthState> Solve();
}
