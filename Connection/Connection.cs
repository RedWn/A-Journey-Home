abstract class Connection
{
    public Station TargetStation;
    public ConnectionType Type;
    public string? BusRouteName;

    protected float SpeedInKPH;
    protected float DistanceInKm;

    protected Connection(Station targetStation, float distanceInKm, float speedInKph)
    {
        TargetStation = targetStation;
        DistanceInKm = distanceInKm;
        SpeedInKPH = speedInKph;
    }

    public float GetTimeChange()
    {
        return DistanceInKm / SpeedInKPH;
    }

    public abstract float GetMoneyChange();
    public abstract float GetHPChange();
}

class BusConnection : Connection
{
    public BusConnection(Station targetStation, float distanceInKm, float speedInKph, string routeName) : base(targetStation, distanceInKm, speedInKph)
    {
        Type = ConnectionType.BUS;
        BusRouteName = routeName;
    }

    override public float GetMoneyChange()
    {
        return -400;
    }

    override public float GetHPChange()
    {
        return -5 * DistanceInKm;
    }
}

class TaxiConnection : Connection
{
    public TaxiConnection(Station targetStation, float distanceInKm, float speedInKph) : base(targetStation, distanceInKm, speedInKph)
    {
        Type = ConnectionType.TAXI;
    }
    override public float GetMoneyChange()
    {
        return -1000 * DistanceInKm;
    }

    override public float GetHPChange()
    {
        return 5 * DistanceInKm;
    }
}

class OnFootConnection : Connection
{
    public OnFootConnection(Station targetStation, float distanceInKm, float speedInKph) : base(targetStation, distanceInKm, speedInKph)
    {
        Type = ConnectionType.ON_FOOT;
    }

    override public float GetMoneyChange()
    {
        return 0;
    }

    override public float GetHPChange()
    {
        return (-1) * 10 * DistanceInKm;
    }
}