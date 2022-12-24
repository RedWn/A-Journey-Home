abstract class Connection {
	public Station targetStation;
	protected int distanceInKm;
	protected int speedInKph;

	protected Connection(Station targetStation, int distanceInKm, int speedInKph) {
		this.targetStation = targetStation;
		this.distanceInKm = distanceInKm;
		this.speedInKph = speedInKph;
	}

	public abstract int getTimeChange();
	public abstract int getMoneyChange();
	public abstract int getHpChange();
}

class BusConnection: Connection {
	public BusConnection(Station targetStation, int distanceInKm, int speedInKph): base(targetStation, distanceInKm, speedInKph) {}

	override public int getTimeChange() {
		return -1 * (this.distanceInKm / this.speedInKph);
	}

	override public int getMoneyChange() {
		return -400;
	}

	override public int getHpChange() {
		return -5 * this.distanceInKm;
	}
}

class TaxiConnection: Connection {
	public TaxiConnection(Station targetStation, int distanceInKm, int speedInKph): base(targetStation, distanceInKm, speedInKph) {}

	override public int getTimeChange() {
		return -1 * (this.distanceInKm / this.speedInKph);
	}

	override public int getMoneyChange() {
		return -1000 * this.distanceInKm;
	}

	override public int getHpChange() {
		return +5 * this.distanceInKm;
	}
}

class OnFootConnection: Connection {
	public OnFootConnection(Station targetStation, int distanceInKm, int speedInKph): base(targetStation, distanceInKm, speedInKph) {}

	override public int getTimeChange() {
		return -1 * (this.distanceInKm / this.speedInKph);
	}

	override public int getMoneyChange() {
		return 0;
	}

	override public int getHpChange() {
		return -5 * this.distanceInKm;
	}
}