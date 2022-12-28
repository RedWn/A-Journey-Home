class Station
{
    public readonly string Name;
    public readonly float TaxiWaitTime;
    public readonly float BusWaitTime;

    public readonly StationLocation Location;
    public readonly List<Connection> Connections;

    public Station(string name, float taxiWaitTime, float busWaitTime, StationLocation location)
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
        connection = ConnectionFactory.GetConnection(ConnectionType.ON_FOOT, targetStation, distanceInKm, 5.5f);
        Connections.Add(connection);
    }

    public float GetWaitingTime(Connection connection)
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

    public float CalcGeoDistTo(Station s)
    {
        // Simple euclidean distance calculation
        float distanceYSquared = MathF.Pow(Location.x - s.Location.x, 2);
        float distanceXSquared = MathF.Pow(Location.y - s.Location.y, 2);

        return MathF.Sqrt(distanceXSquared + distanceYSquared) * 0.1f; //0.1 is to convert from coordinates to KM
    }
}