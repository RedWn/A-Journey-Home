using System.Diagnostics;

static class Solver
{
    private static readonly Stopwatch _stopWatch = new();
    private static readonly HashSet<string> _visited = new();
    private static readonly Dictionary<State, State?> _parents = new();

    private static int _numberOfVisitedNodes = 0;

    public static void Solve(State initialState, IComparer<StatePriority> comparer, Heuristics.HeuristicCalculator heuristicCalculator)
    {
        _stopWatch.Start();

        PriorityQueue<State, StatePriority> _queue = new(comparer);

        State? finalState = null;
        _parents[initialState] = null;

        var initialStatePriority = new StatePriority(initialState.TimeSpentInHours, initialState.AvailableHP, initialState.AvailableMoney, 0);
        _queue.Enqueue(initialState, initialStatePriority);

        while (_queue.Count > 0)
        {
            State state = _queue.Dequeue();

            if (state.IsFinal())
            {
                finalState = state;
                break;


                //if (finalState is null)
                //    finalState = state;
                //else
                //{
                //    var finalpriority = new StatePriority(finalState.TimeSpentInHours, finalState.AvailableHP, finalState.AvailableMoney, heuristicCalculator(finalState.Station, Program.HOME_STATION));
                //    var priority = new StatePriority(state.TimeSpentInHours, state.AvailableHP, state.AvailableMoney, heuristicCalculator(state.Station, Program.HOME_STATION));
                //    if (comparer.Compare(finalpriority, priority) == 1)
                //        finalState = state;
                //}
            }

            _visited.Add(state.GetHash());
            _numberOfVisitedNodes++;

            foreach (State nextState in state.GetNextStates())
            {
                if (_visited.Contains(nextState.GetHash())) continue;
                var priority = new StatePriority(nextState.TimeSpentInHours, nextState.AvailableHP, nextState.AvailableMoney, heuristicCalculator(nextState.Station, Program.HOME_STATION));
                _queue.Enqueue(nextState, priority);
                _parents[nextState] = state;
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

        Console.WriteLine("");

        while (statesPath.Count > 0)
        {
            var state = statesPath.Pop();
            Console.WriteLine($"Station: {state.Station.Name}");
            Console.WriteLine($"Transportation Method: {state.PreviousConnection?.Type}");
            Console.WriteLine($"HP: {state.AvailableHP} \t Time Spent: {state.TimeSpentInHours * 60} \t Money: {state.AvailableMoney}");
            Console.WriteLine();
        }
    }
}