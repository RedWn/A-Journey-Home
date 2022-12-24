class Program {
	public static Station? HOME_STATION;
	public static int INITIAL_MONEY = 100;

	public static void Main() {
		Station university = new Station("university", 10, 10);
		Station jaramana = new Station("jaramana", 20, 30);
		Station karajElSet = new Station("karaj el set", 10, 5);
		HOME_STATION = new Station("rukn al dein", 5, 30);

		university.addConnection(ConnectionType.BUS, jaramana, 200, 20);
		jaramana.addConnection(ConnectionType.BUS, karajElSet, 100, 70);
		karajElSet.addConnection(ConnectionType.BUS, HOME_STATION, 30, 3000);
	}
}