using System.Diagnostics;

static class Solver
{
    private static Dictionary<State, State?> _parents = new();
    private static PriorityQueue<State, float> _queue = new();
    private static HashSet<State> _visited = new();
    private static Stopwatch _stopWatch = new();
    private static int _numberOfVisitedNodes = 0;

    public static void Solve(State initialState)
    {
        _stopWatch.Start();

        State? finalState = null;
        _parents[initialState] = null;
        _queue.Enqueue(initialState, initialState.TimeSpent);

        bool shouldBreakLoop = false;

        while (_queue.Count > 0)
        {
            if (shouldBreakLoop) break;

            State state = _queue.Dequeue();
            if (_visited.Contains(state)) continue;
            _visited.Add(state);
            _numberOfVisitedNodes++;

            List<State> nextStates = state.GetNextStates();
            foreach (State nextState in nextStates)
            {
                float priority = nextState.TimeSpent;
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

        State s = _parents[finalState];
        while (s is not null)
        {
            statesPath.Push(s);
            s = _parents[s];
        }

        while (statesPath.Count > 0)
        {
            var state = statesPath.Pop();
            Console.WriteLine($"Station: {state.Station.Name} - {state.PreviousConnection?.Type}");
            Console.WriteLine($"HP: {state.AvailableHP}, Time Spent: {state.TimeSpent}, Money: {state.AvailableMoney}");
            Console.WriteLine();
        }

        Console.WriteLine("Home... after 5 years on the east cost, it was time to go home.");
    }
}