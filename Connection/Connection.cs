abstract class Connection
{
    public Station TargetStation;
    public ConnectionType Type;
    public string? BusRouteName;

    protected float SpeedInKPH;
    protected int DistanceInKm;

    protected Connection(Station targetStation, int distanceInKm, float speedInKph)
    {
        TargetStation = targetStation;
        DistanceInKm = distanceInKm;
        SpeedInKPH = speedInKph;
    }

    public float GetTimeChange()
    {
        return DistanceInKm / SpeedInKPH;
    }

    public abstract int GetMoneyChange();
    public abstract int GetHPChange();
    public float getSpeed()
    {
        return SpeedInKPH;
    }
}

class BusConnection : Connection
{
    public BusConnection(Station targetStation, int distanceInKm, float speedInKph, string routeName) : base(targetStation, distanceInKm, speedInKph)
    {
        Type = ConnectionType.BUS;
        BusRouteName = routeName;
    }


    override public int GetMoneyChange()
    {
        return -400;
    }

    override public int GetHPChange()
    {
        return -5 * DistanceInKm;
    }
}

class TaxiConnection : Connection
{
    public TaxiConnection(Station targetStation, int distanceInKm, float speedInKph) : base(targetStation, distanceInKm, speedInKph)
    {
        Type = ConnectionType.TAXI;
    }


    override public int GetMoneyChange()
    {
        return (-1) * 1000 * DistanceInKm;
    }

    override public int GetHPChange()
    {
        return 5 * DistanceInKm;
    }
}

class OnFootConnection : Connection
{
    public OnFootConnection(Station targetStation, int distanceInKm, float speedInKph) : base(targetStation, distanceInKm, speedInKph)
    {
        Type = ConnectionType.ON_FOOT;
    }

    override public int GetMoneyChange()
    {
        return 0;
    }

    override public int GetHPChange()
    {
        return (-1) * 10 * DistanceInKm;
    }
}