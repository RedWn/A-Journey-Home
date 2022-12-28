class Station
{
    public readonly string Name;
    public readonly float TaxiWaitTime;
    public readonly float BusWaitTime;

    public readonly StationLocation Location;
    public readonly List<Connection> Connections;

    private HashSet<Connection> _onFootConnections;

    public Station(string name, float taxiWaitTime, float busWaitTime, StationLocation location)
    {
        Name = name;
        TaxiWaitTime = taxiWaitTime;
        BusWaitTime = busWaitTime;
        Location = location;

        Connections = new List<Connection>();
        _onFootConnections = new HashSet<Connection>();
    }

    public void AddConnection(ConnectionType type, Station targetStation, float distanceInKm, float speedInKph, string routeName = "")
    {
        Connection connection = ConnectionFactory.GetConnection(type, targetStation, distanceInKm, speedInKph, routeName);
        Connections.Add(connection);


        // We're adding onFoot connections here because adding them manually from the main program
        // is a pain in the back. To ensure that we only have one ON_FOOT_CONNECTION for each targetStation,
        // we have the _onFootConnections HashSet.

        Connection onFootConnection = ConnectionFactory.GetConnection(ConnectionType.ON_FOOT, targetStation, distanceInKm, 5.5f);
        if (!_onFootConnections.Contains(onFootConnection))
        {
            Connections.Add(onFootConnection);
            _onFootConnections.Add(onFootConnection);
        }
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

        float COORDINATE_TO_KM_CONVERSION_FACTOR = 0.1f;

        return MathF.Sqrt(distanceXSquared + distanceYSquared) * COORDINATE_TO_KM_CONVERSION_FACTOR; 
    }
}