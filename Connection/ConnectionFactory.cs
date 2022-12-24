static class ConnectionFactory
{
   public static Connection GetConnection(ConnectionType type, Station targetStation, int distanceInKm,
                                bool isPaved, float busSpeedInKph, float taxiSpeedInKph, string route)
    {
        return type switch
        {
            ConnectionType.BUS => new BusConnection(targetStation, distanceInKm, isPaved, busSpeedInKph, taxiSpeedInKph, route),
            ConnectionType.TAXI => new TaxiConnection(targetStation, distanceInKm, isPaved, busSpeedInKph, taxiSpeedInKph, route),
            ConnectionType.ON_FOOT => new OnFootConnection(targetStation, distanceInKm, isPaved, busSpeedInKph, taxiSpeedInKph, route),
            _ => new BusConnection(targetStation, distanceInKm, isPaved, busSpeedInKph, taxiSpeedInKph, route)
        };
    }
}
 
