static class ConnectionFactory
{
    public static Connection GetConnection(ConnectionType type, Station targetStation, float distanceInKm, float speedInKph, string routeName = "")
    {
        return type switch
        {
            ConnectionType.BUS => new BusConnection(targetStation, distanceInKm, speedInKph, routeName),
            ConnectionType.TAXI => new TaxiConnection(targetStation, distanceInKm, speedInKph),
            ConnectionType.ON_FOOT => new OnFootConnection(targetStation, distanceInKm, speedInKph),
            _ => new BusConnection(targetStation, distanceInKm, speedInKph, routeName)
        };
    }
}

