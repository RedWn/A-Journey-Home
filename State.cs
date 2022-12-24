class State {
	public Station station;
	public int timeSpent, hp, money;

	public State(Station station, int timeSpent, int hp, int money) {
		this.station = station;
		this.timeSpent = timeSpent;
		this.hp = hp;
		this.money = money;
	}

	public void choosePath(Connection path) {
		this.station = path.targetStation;

		// Wait for bus/taxi
		if (path is BusConnection) {
			this.timeSpent += this.station.busWaitTime;
		} else if (path is TaxiConnection) {
			this.timeSpent += this.station.taxiWaitTime;
		}

		// Ride the bus/taxi
		this.timeSpent += path.getTimeChange();
		this.hp += path.getHpChange();
		this.money += path.getMoneyChange();
	}

	public List<State> getNextStates() {
		List<State> nextStates = new List<State>();

		foreach (Connection connection in this.station.connections) {
			if (this.canTakeConnection(connection)) {
				State stateClone = this.clone();
				stateClone.choosePath(connection);
				nextStates.Add(stateClone);
			}
		}

		return nextStates;
	}

	bool canTakeConnection(Connection path) {
		int futureMoney = this.money + path.getMoneyChange();
		int futureHp = this.hp + path.getHpChange();

		return futureMoney <= Program.INITIAL_MONEY && futureHp > 0;
	}

	public bool isFinal() {
		return this.station == Program.HOME_STATION;
	}

	State clone() {
		return new State(this.station, this.timeSpent, this.hp, this.money);
	}
}