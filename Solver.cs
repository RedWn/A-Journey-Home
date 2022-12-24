class Solver {
	public void solve(State initialState) {
		List<State> visited = new List<State>();
		PriorityQueue<State, int> queue = new PriorityQueue<State, int>();

		bool shouldBreakLoop = false;
		while (queue.Count > 0) {
			if (shouldBreakLoop) break;
			
			State state = queue.Dequeue();

			if (visited.Contains(state)) continue;
			visited.Add(state);

			List<State> nextStates = state.getNextStates();

			foreach (State nextState in nextStates) {
				// Here, priority is timespent 
				queue.Enqueue(nextState, nextState.timeSpent);

				if (nextState.isFinal()) {
					shouldBreakLoop = true;
					break;
				}
			}
		}
	}
}