class Station
{
    public readonly string Name;
    public readonly int TaxiWaitTime;
    public readonly int BusWaitTime;

    public readonly StationLocation Location;
    public readonly List<Connection> Connections;

    public Station(string name, int taxiWaitTime, int busWaitTime, StationLocation location)
    {
        Name = name;
        TaxiWaitTime = taxiWaitTime;
        BusWaitTime = busWaitTime;
        Location = location;

        Connections = new List<Connection>();
    }

    public void AddConnection(ConnectionType type, Station targetStation, float distanceInKm, float speedInKph, string routeName = "")
    {
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

    public float CalculateGeographicalDistanceToStation(Station s)
    {
        // Simple euclidean distance calculation
        float distanceYSquared = MathF.Pow(Location.x - s.Location.x, 2);
        float distanceXSquared = MathF.Pow(Location.y - s.Location.y, 2);

        return MathF.Sqrt(distanceXSquared + distanceYSquared);
    }
}