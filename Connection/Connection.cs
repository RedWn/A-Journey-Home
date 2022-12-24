abstract class Connection {
	public Station TargetStation;
	protected int DistanceInKm;
	protected int SpeedInKPH;

	protected Connection(Station targetStation, int distanceInKm, int speedInKph) {
		TargetStation = targetStation;
		DistanceInKm = distanceInKm;
		SpeedInKPH = speedInKph;
	}

	public int GetTimeChange()
	{
        return DistanceInKm / SpeedInKPH;
    }

	public abstract int GetMoneyChange();
	public abstract int GetHPChange();
}

class BusConnection: Connection {
	public BusConnection(Station targetStation, int distanceInKm, int speedInKph): base(targetStation, distanceInKm, speedInKph) {}


	override public int GetMoneyChange() {
		return -400;
	}

	override public int GetHPChange() {
		return -5 * DistanceInKm;
	}
}

class TaxiConnection: Connection {
	public TaxiConnection(Station targetStation, int distanceInKm, int speedInKph): base(targetStation, distanceInKm, speedInKph) {}


	override public int GetMoneyChange() {
		return (-1) * 1000 * DistanceInKm;
	}

	override public int GetHPChange() {
		return 5 * DistanceInKm;
	}
}

class OnFootConnection: Connection {
	public OnFootConnection(Station targetStation, int distanceInKm, int speedInKph): base(targetStation, distanceInKm, speedInKph) {}

	override public int GetMoneyChange() {
		return 0;
	}

	override public int GetHPChange() {
		return (-1) * 10 * DistanceInKm;
	}
}