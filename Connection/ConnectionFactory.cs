static class ConnectionFactory
{
    public static List<Connection> GetConnection(Station targetStation, int distanceInKm,
                                bool isPaved, float? busSpeedInKph, float? taxiSpeedInKph, string? route)
    {
        if (isPaved)
        {
            if (busSpeedInKph != null && route != null && taxiSpeedInKph != null)
            {
                return new List<Connection> {
                    new BusConnection(targetStation, distanceInKm, busSpeedInKph.Value, route),
                    new TaxiConnection(targetStation, distanceInKm, taxiSpeedInKph.Value),
                    new OnFootConnection(targetStation, distanceInKm)
                };
            }
            return new List<Connection> { };
        }
        else
        {
            return new List<Connection> { new OnFootConnection(targetStation, distanceInKm) };
        }
    }
}