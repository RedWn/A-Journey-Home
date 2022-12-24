class Station {
	public readonly string Name;

	public int TaxiWaitTime { get; private set; }
	public int BusWaitTime { get; private set; }

	public List<Connection> Connections;

	public Station(string name, int taxiWaitTime, int busWaitTime) {
		Name = name;
		TaxiWaitTime = taxiWaitTime;
		BusWaitTime = busWaitTime;

		Connections = new List<Connection>();
	}

	public void AddConnection(ConnectionType type, Station targetStation, int distanceInKm, int speedInKph) {
		Connection connection = ConnectionFactory.GetConnection(type, targetStation, distanceInKm, speedInKph);
		Connections.Add(connection);
	}

	public int GetWaitingTime(Connection connection)
	{
        if (connection is BusConnection)
        {
            return BusWaitTime;
		}

        else if (connection is TaxiConnection)
        {
            return TaxiWaitTime;
        }

		return 0;
    }
}