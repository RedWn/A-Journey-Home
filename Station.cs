class Station {
	public string name;
	public int taxiWaitTime;
	public int busWaitTime;
	public List<Connection> connections;

	public Station(string name, int taxiWaitTime, int busWaitTime) {
		this.name = name;
		this.taxiWaitTime = taxiWaitTime;
		this.busWaitTime = busWaitTime;

		this.connections = new List<Connection>();
	}

	public void addConnection(ConnectionType type, Station targetStation, int distanceInKm, int speedInKph) {
		Connection connection;

		if (type  == ConnectionType.BUS) {
			connection = new BusConnection(targetStation, distanceInKm, speedInKph);
		} else if (type == ConnectionType.TAXI) {
			connection = new TaxiConnection(targetStation, distanceInKm, speedInKph);
		} else {
			connection = new OnFootConnection(targetStation, distanceInKm, speedInKph);
		}

		this.connections.Add(connection);
	}
}

public enum ConnectionType { BUS, TAXI, ON_FOOT };