abstract class Connection {
	public Station TargetStation;
	protected int DistanceInKm;
	protected float? BusSpeedInKPH;
	protected float? TaxiSpeedInKPH;
	protected string? RouteName;

	protected Connection(Station targetStation, int distanceInKm, bool isPaved,
							float busSpeedInKph, float taxiSpeedInKph, string route) {
		TargetStation = targetStation;
		DistanceInKm = distanceInKm;
		if(isPaved){
			BusSpeedInKPH = busSpeedInKph;
			TaxiSpeedInKPH = taxiSpeedInKph;
			RouteName = route;
		}
	}

	public abstract float GetTimeChange();
	public abstract int GetMoneyChange();
	public abstract int GetHPChange();
}

class BusConnection: Connection {
	public BusConnection(Station targetStation, int distanceInKm, bool isPaved,
						float busSpeedInKph, float taxiSpeedInKph, string route)
		: base(targetStation, distanceInKm, isPaved, busSpeedInKph, taxiSpeedInKph, route) {}


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
	public TaxiConnection(Station targetStation, int distanceInKm, bool isPaved,
							float busSpeedInKph, float taxiSpeedInKph, string route)
		: base(targetStation, distanceInKm, isPaved, busSpeedInKph, taxiSpeedInKph, route) {}


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
	public OnFootConnection(Station targetStation, int distanceInKm, bool isPaved,
								float busSpeedInKph, float taxiSpeedInKph, string route)
		: base(targetStation, distanceInKm, isPaved, busSpeedInKph, taxiSpeedInKph, route) {}

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