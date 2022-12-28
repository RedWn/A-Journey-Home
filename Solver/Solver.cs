using System.Diagnostics;

static class Solver
{
    private static Dictionary<State, State?> _parents = new();
    private static HashSet<State> _visited = new();
    private static Stopwatch _stopWatch = new();
    private static int _numberOfVisitedNodes = 0;

    public static void Solve(State initialState, IComparer<StatePriority> comparer, Heuristics.HeuristicCalculator heuristicCalculator)
    {
        _stopWatch.Start();

        PriorityQueue<State, StatePriority> _queue = new(comparer);

        State? finalState = null;
        _parents[initialState] = null;

        var initialStatePriority = new StatePriority(initialState.TimeSpentInHours, initialState.AvailableHP, initialState.AvailableMoney, 0);
        _queue.Enqueue(initialState, initialStatePriority);

        bool shouldBreakLoop = false;

        while (_queue.Count > 0)
        {
            if (shouldBreakLoop) break;

            State state = _queue.Dequeue();
            if (_visited.Contains(state)) continue;

            _visited.Add(state);
            _numberOfVisitedNodes++;

            foreach (State nextState in state.GetNextStates())
            {
                var priority = new StatePriority(nextState.TimeSpentInHours, nextState.AvailableHP, nextState.AvailableMoney, heuristicCalculator(nextState.Station, Program.HOME_STATION));
                _queue.Enqueue(nextState, priority);
                _parents[nextState] = state;

                if (nextState.IsFinal())
                {
                    shouldBreakLoop = true;
                    finalState = nextState;
                    break;
                }
            }
        }

        _stopWatch.Stop();
        if (finalState is not null) printSolutionDetails(finalState);
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

        Console.WriteLine("\n\n\n\n");

        while (statesPath.Count > 0)
        {
            var state = statesPath.Pop();
            Console.WriteLine($"Station: {state.Station.Name}");
            Console.WriteLine($"Transportation Method: {state.PreviousConnection?.Type}");
            Console.WriteLine($"HP: {state.AvailableHP} \t Time Spent: {state.TimeSpentInHours * 60} \t Money: {state.AvailableMoney}");
            Console.WriteLine();
        }

        Console.WriteLine("Home... after 5 years on the east cost, it was time to go home."); //CJ
    }
}