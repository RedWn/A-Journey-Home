abstract class Connection
{
    public Station TargetStation;
    protected int DistanceInKm;

    protected Connection(Station targetStation, int distanceInKm)
    {
        TargetStation = targetStation;
        DistanceInKm = distanceInKm;
    }

    public abstract float GetTimeChange();
    public abstract int GetMoneyChange();
    public abstract int GetHPChange();
}

class BusConnection : Connection
{
	protected float BusSpeedInKPH;
    protected string RouteName;
    public BusConnection(Station targetStation, int distanceInKm, float busSpeedInKph, string route)
        : base(targetStation, distanceInKm)
    {
        BusSpeedInKPH = busSpeedInKph;
        RouteName = route;
    }

    override public int GetMoneyChange()
    {
        return -400;
    }

    override public int GetHPChange()
    {
        return -5 * DistanceInKm;
    }
    override public float GetTimeChange()
    {
        return DistanceInKm / BusSpeedInKPH;
    }
}

class TaxiConnection : Connection
{
    public float TaxiSpeedInKPH;
    public TaxiConnection(Station targetStation, int distanceInKm, float taxiSpeedInKph)
        : base(targetStation, distanceInKm)
    {
        TaxiSpeedInKPH = taxiSpeedInKph;
    }

    override public int GetMoneyChange()
    {
        return (-1) * 1000 * DistanceInKm;
    }

    override public int GetHPChange()
    {
        return 5 * DistanceInKm;
    }
    override public float GetTimeChange()
    {
        return DistanceInKm / TaxiSpeedInKPH;
    }
}

class OnFootConnection : Connection
{
    public OnFootConnection(Station targetStation, int distanceInKm)
        : base(targetStation, distanceInKm) { }

    override public int GetMoneyChange()
    {
        return 0;
    }

    override public int GetHPChange()
    {
        return (-1) * 10 * DistanceInKm;
    }
    override public float GetTimeChange()
    {
        return DistanceInKm / 5.5f;
    }
}