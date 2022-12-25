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

	public void AddConnection(ConnectionType type, Station targetStation, int distanceInKm, float speedInKph, string routeName = "") {
		Connection connection = ConnectionFactory.GetConnection(type, targetStation, distanceInKm, speedInKph, routeName);
		Connections.Add(connection);
	}

	public int GetWaitingTime(Connection connection)
	{
        if (connection.Type == ConnectionType.BUS)
        {
            return BusWaitTime;
		}

        else if (connection.Type == ConnectionType.TAXI)
        {
            return TaxiWaitTime;
        }

		return 0;
    }
}