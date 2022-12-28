// Reference: https://dotnetcoretutorials.com/2021/03/17/priorityqueue-in-net/#:~:text=A%20Priority%20Queue%20is%20a,when%20it%20was%20put%20on.
/**
 * Comparator return values quick reference: 
 * 
 *  0    : Items are equal
 * -1    : Choose first parameter
 *  1    : Choose second parameter
 **/

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
        float dTimeSpentX = MathF.Pow(x.TimeSpent, 2);
        float dAvailableHPX = MathF.Pow(x.AvailableHP, 2);
        float dAvailableMoneyX = MathF.Pow(x.AvailableMoney, 2);
        float bigDx = MathF.Sqrt(-dTimeSpentX + dAvailableHPX + dAvailableMoneyX);

        float dTimeSpentY = MathF.Pow(y.TimeSpent, 2);
        float dAvailableHPY = MathF.Pow(y.AvailableHP, 2);
        float dAvailableMoneyY = MathF.Pow(y.AvailableMoney, 2);
        float bigDy = MathF.Sqrt(-dTimeSpentY + dAvailableHPY + dAvailableMoneyY);
        if (bigDx < bigDy) return -1;
        return 1;
    }
}