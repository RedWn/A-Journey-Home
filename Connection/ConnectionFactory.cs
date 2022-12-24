static class ConnectionFactory
{
   public static Connection GetConnection(ConnectionType type, Station targetStation, int distanceInKm, int speedInKph)
    {
        return type switch
        {
            ConnectionType.BUS => new BusConnection(targetStation, distanceInKm, speedInKph),
            ConnectionType.TAXI => new TaxiConnection(targetStation, distanceInKm, speedInKph),
            ConnectionType.ON_FOOT => new OnFootConnection(targetStation, distanceInKm, speedInKph),
            _ => new BusConnection(targetStation, distanceInKm, speedInKph)
        };
    }
}
 
