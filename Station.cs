class Station {
	public string name;
	public int taxiWaitTime;
	public int busWaitTime;
	public List<Connection> connections;

	Station(string name, int taxiWaitTime, int busWaitTime) {
		this.name = name;
		this.taxiWaitTime = taxiWaitTime;
		this.busWaitTime = busWaitTime;

		this.connections = new List<Connection>();
	}

	public void addConnection(Connection connection) {
		this.connections.Add(connection);
	}
}