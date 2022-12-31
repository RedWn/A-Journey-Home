// Reference: https://dotnetcoretutorials.com/2021/03/17/priorityqueue-in-net/#:~:text=A%20Priority%20Queue%20is%20a,when%20it%20was%20put%20on.
/**
 * Comparator return values quick reference: 
 * 
 *  0    : Items are equal
 * -1    : Choose first parameter
 *  1    : Choose second parameter
 **/

using System.Numerics;
public class BestTimeGoal : IComparer<StatePriority>
{
    public int Compare(StatePriority x, StatePriority y)
    {
        if (x.TimeSpent + x.heuristic == y.TimeSpent + y.heuristic) return 0;
        if (x.TimeSpent + x.heuristic < y.TimeSpent + y.heuristic) return -1;
        return 1;
    }
}

public class BestMoneyGoal : IComparer<StatePriority>
{
    public int Compare(StatePriority x, StatePriority y)
    {
        if (x.AvailableMoney + x.heuristic == y.AvailableMoney + y.heuristic) return 0;
        if (x.AvailableMoney + x.heuristic > y.AvailableMoney + y.heuristic) return -1;
        return 1;
    }
}

public class BestHPGoal : IComparer<StatePriority>
{
    public int Compare(StatePriority x, StatePriority y)
    {
        if (x.AvailableHP + x.heuristic == y.AvailableHP + y.heuristic) return 0;
        if (x.AvailableHP + x.heuristic > y.AvailableHP + y.heuristic) return -1;
        return 1;
    }
}

public class BestAllGoal : IComparer<StatePriority> //this is testing ground and is not complete AT ALL
{
    public int Compare(StatePriority x, StatePriority y)
    {
        if ((x.TimeSpent, x.AvailableHP, x.AvailableMoney) == (y.TimeSpent, y.AvailableHP, y.AvailableMoney)) return 0;
        if ((-x.TimeSpent * 0.022f + x.AvailableHP * 0.2f + x.heuristic) > (-y.TimeSpent * 0.022f + y.AvailableHP * 0.2f + y.heuristic)) return -1;
        return 1;
    }
}