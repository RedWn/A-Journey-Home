using System.Diagnostics;

static class Solver
{
    private static Dictionary<State, State?> _parents = new();
    private static HashSet<State> _visited = new();
    private static Stopwatch _stopWatch = new();
    private static int _numberOfVisitedNodes = 0;

    public static void Solve(State initialState, IComparer<StateInfo> comparer)
    {
        PriorityQueue<State, StateInfo> _queue = new();
        _stopWatch.Start();

        State? finalState = null;
        _parents[initialState] = null;
        _queue.Enqueue(initialState, new StateInfo(initialState.TimeSpent, initialState.AvailableHP, initialState.AvailableMoney, 0));

        bool shouldBreakLoop = false;

        while (_queue.Count > 0)
        {
            if (shouldBreakLoop) break;

            State state = _queue.Dequeue();
            if (_visited.Contains(state)) continue;
            _visited.Add(state);
            _numberOfVisitedNodes++;

            List<State> nextStates = state.GetNextStation();
            foreach (State nextState in nextStates)
            {
                var priority = new StateInfo(nextState.TimeSpent, nextState.AvailableHP, nextState.AvailableMoney, getTimeHeuristics(state.Station, Program.HOME_STATION));
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

        while (statesPath.Count > 0)
        {
            var state = statesPath.Pop();
            Console.WriteLine($"Station: {state.Station.Name} - {state.PreviousConnection?.Type}");
            Console.WriteLine($"HP: {state.AvailableHP}, Time Spent: {state.TimeSpent}, Money: {state.AvailableMoney}");
            Console.WriteLine();
        }

        Console.WriteLine("Home... after 5 years on the east cost, it was time to go home."); //CJ
    }

    //Heuristics here are still plug and play and can't be changed in runtime, we need to find the a walkaround or live life as is
    private static float getTimeHeuristics(Station S1, Station S2)
    {
        //Every quest should ALSO have this function rewritten
        float distance = MathF.Sqrt(MathF.Pow(S2.location.y - S1.location.y, 2) + MathF.Pow(S2.location.x - S1.location.x, 2));
        float time = distance / 45; //45 is an arbitrary number that happens to be the mean speed of vehicle transportation downtown
        return time;
    }

    private static float getHPHeuristics(Station S, Station S2)
    {
        //Every quest should ALSO have this function rewritten
        float distance = MathF.Sqrt(MathF.Pow(S2.location.y - S.location.y, 2) + MathF.Pow(S2.location.x - S.location.x, 2));
        float dHP = distance * -3.4f; //-3.4 HP per KM is the average of HP differential between -10 for walking, -5 for buses and +5 for taxis 
        return dHP;
    }

    private static float getMoneyHeuristics(Station S, Station S2)
    {
        //Every quest should ALSO have this function rewritten
        float distance = MathF.Sqrt(MathF.Pow(S2.location.y - S.location.y, 2) + MathF.Pow(S2.location.x - S.location.x, 2));
        float money = distance * -1000; //TODO: get a realistic number to put here
        return money;
    }
}