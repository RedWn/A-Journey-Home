using System.Diagnostics;

static class Solver
{
    private static readonly Stopwatch _stopWatch = new();
    private static readonly HashSet<string> _visited = new();
    private static readonly Dictionary<State, State?> _parents = new();
    private static int _numberOfVisitedNodes = 0;

    private static void solve(State initialState, IComparer<StatePriority> comparer, Heuristics.HeuristicCalculator heuristicCalculator)
    {
        _stopWatch.Start();

        PriorityQueue<State, StatePriority> _queue = new(comparer);

        State? finalState = null;
        _parents[initialState] = null;

        int initialHeuristicValue = 0;

        var initialStatePriority = new StatePriority(initialState.TimeSpentInHours, initialState.AvailableHP, initialState.AvailableMoney, initialHeuristicValue);
        
        _queue.Enqueue(initialState, initialStatePriority);

        while (_queue.Count > 0)
        {
            State state = _queue.Dequeue();

            if (state.IsFinal())
            {
                finalState = state;
                break;
            }

            _visited.Add(state.GetHash());
            _numberOfVisitedNodes++;

            foreach (State nextState in state.GetNextStates())
            {
                if (_visited.Contains(nextState.GetHash())) continue;
                var priority = new StatePriority(nextState.TimeSpentInHours, nextState.AvailableHP, nextState.AvailableMoney, heuristicCalculator(nextState.Station, Program.HOME_STATION));
                _parents[nextState] = state;
                _queue.Enqueue(nextState, priority);
            }
        }

        _stopWatch.Stop();
        if (finalState is not null) printSolutionDetails(finalState);
        else Console.WriteLine("No possible routes found!");
    }

    public static void SolveForBestTime(State initialState)
    {
        Heuristics.HeuristicCalculator h = Heuristics.timeHeuristic;
        IComparer<StatePriority> comparer = new BestTimeGoal();
        solve(initialState, comparer, h);
    }

    public static void SolveForBestHP(State initialState)
    {
        Heuristics.HeuristicCalculator h = Heuristics.hpHeuristic;
        IComparer<StatePriority> comparer = new BestHPGoal();
        solve(initialState, comparer, h);
    }

    public static void SolveForBestMoney(State initialState)
    {
        Heuristics.HeuristicCalculator h = Heuristics.moneyHeuristic;
        IComparer<StatePriority> comparer = new BestMoneyGoal();
        solve(initialState, comparer, h);
    }

    public static void SolveForAllBestConditions(State initialState)
    {
        Heuristics.HeuristicCalculator h = Heuristics.allHeuristic;
        IComparer<StatePriority> comparer = new BestAllGoal();
        solve(initialState, comparer, h);
    }

    private static void printSolutionDetails(State finalState)
    {
        Console.WriteLine($"Time taken: {_stopWatch.Elapsed.TotalSeconds}");
        Console.WriteLine($"Number of visited nodes: {_numberOfVisitedNodes}");

        // Generate student path
        Stack<State> statesPath = new();

        State s = finalState;
        while (s is not null)
        {
            statesPath.Push(s);
            s = _parents[s];
        }

        Console.WriteLine("");

        while (statesPath.Count > 0)
        {
            var state = statesPath.Pop();
            Console.WriteLine($"Station: {state.Station.Name}");
            Console.WriteLine($"Transportation Method: {state.PreviousConnection?.Type}");
            Console.WriteLine($"HP: {state.AvailableHP} \t Time Spent: {state.TimeSpentInHours * 60} Minutes \t Money: {state.AvailableMoney} Syrian Pounds");
            Console.WriteLine();
        }
    }
}