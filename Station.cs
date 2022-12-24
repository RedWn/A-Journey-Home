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

	public void AddConnection( Station targetStation, int distanceInKm,
						 		bool isPaved, float? busSpeedInKph, float? taxiSpeedInKph, string? route) {
		List<Connection> list = ConnectionFactory.GetConnection(
													 targetStation,
													 distanceInKm,
													 isPaved,
													 busSpeedInKph,
													 taxiSpeedInKph,
													 route
													);
		Connections.Add(list[0]);
		if(list.Count() == 2){
			Connections.Add(list[1]);
		}
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