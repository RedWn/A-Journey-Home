// Reference: https://dotnetcoretutorials.com/2021/03/17/priorityqueue-in-net/#:~:text=A%20Priority%20Queue%20is%20a,when%20it%20was%20put%20on.

public class BestTimeGoal : IComparer<StateInfo>
{

    public int Compare(StateInfo x, StateInfo y)
    {
        if (x.TimeSpent + x.heuristic == y.TimeSpent + y.heuristic) return 0;
        if (x.TimeSpent + x.heuristic < y.TimeSpent + y.heuristic) return -1; // Choose first parameter
        return 1; // Choose second parameter
    }
}

public class BestMoneyGoal : IComparer<StateInfo>
{
    public int Compare(StateInfo x, StateInfo y)
    {
        if (x.AvailableMoney + x.heuristic == y.AvailableMoney + y.heuristic) return 0;
        if (x.AvailableMoney + x.heuristic < y.AvailableMoney + y.heuristic) return -1; // Choose first parameter
        return 1; // Choose second parameter
    }
}

public class BestHPGoal : IComparer<StateInfo>
{
    public int Compare(StateInfo x, StateInfo y)
    {
        if (x.AvailableHP + x.heuristic == y.AvailableHP + y.heuristic) return 0;
        if (x.AvailableHP + x.heuristic < y.AvailableHP + y.heuristic) return -1; // Choose first parameter
        return 1; // Choose second parameter
    }
}

public class BestTimeAndHPAndMoneyGoal : IComparer<StateInfo>
{
    public int Compare(StateInfo x, StateInfo y)
    {
        if ((x.TimeSpent, x.AvailableHP, x.AvailableMoney) == (y.TimeSpent, y.AvailableHP, y.AvailableMoney)) return 0;
        if ((x.TimeSpent < y.TimeSpent) && (x.AvailableHP > y.AvailableHP) && (x.AvailableMoney > y.AvailableMoney)) return -1;
        return 0;
    }
}