abstract class Connection {
	public Station TargetStation;
	protected int DistanceInKm;
	protected float? BusSpeedInKPH;
	protected float? TaxiSpeedInKPH;
	protected string? RouteName;

	//for bus connection
	protected Connection(Station targetStation, int distanceInKm, float busSpeedInKph, string route) {
		TargetStation = targetStation;
		DistanceInKm = distanceInKm;
		BusSpeedInKPH = busSpeedInKph;
		RouteName = route;
	}
	//for taxi connection	
	protected Connection(Station targetStation, int distanceInKm, float taxiSpeedInKph) {
		TargetStation = targetStation;
		DistanceInKm = distanceInKm;
		TaxiSpeedInKPH = taxiSpeedInKph;
	}
	//for on foot connection
	protected Connection(Station targetStation, int distanceInKm) {
		TargetStation = targetStation;
		DistanceInKm = distanceInKm;
	}

	public abstract float GetTimeChange();
	public abstract int GetMoneyChange();
	public abstract int GetHPChange();
}

class BusConnection: Connection {
	public BusConnection(Station targetStation, int distanceInKm, float busSpeedInKph, string route)
		: base(targetStation, distanceInKm,  busSpeedInKph, route) {}

	override public int GetMoneyChange() {
		return -400;
	}

	override public int GetHPChange() {
		return -5 * DistanceInKm;
	}
	override public float GetTimeChange() {
		if(BusSpeedInKPH != null)
			return DistanceInKm / BusSpeedInKPH.Value;
		return 0;
    }
}

class TaxiConnection: Connection {
	public TaxiConnection(Station targetStation, int distanceInKm, float taxiSpeedInKph)
		: base(targetStation, distanceInKm, taxiSpeedInKph) {}


	override public int GetMoneyChange() {
		return (-1) * 1000 * DistanceInKm;
	}

	override public int GetHPChange() {
		return 5 * DistanceInKm;
	}
	override public float GetTimeChange() {
		if(TaxiSpeedInKPH != null)
			return DistanceInKm / TaxiSpeedInKPH.Value;
		return 0;
    }
}

class OnFootConnection: Connection {
	public OnFootConnection(Station targetStation, int distanceInKm)
		: base(targetStation, distanceInKm) {}

	override public int GetMoneyChange() {
		return 0;
	}

	override public int GetHPChange() {
		return (-1) * 10 * DistanceInKm;
	}
	override public float GetTimeChange() {
		return DistanceInKm / 5.5f;
    }
}