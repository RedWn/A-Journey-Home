﻿class Program {
	public static Station? HOME_STATION;

	public static void Main() {
		Station university = new Station("university", 1, 1);
		Station jaramana = new Station("jaramana", 1, 1);
		Station karajElSet = new Station("karaj el set", 1, 1);
		
		Station myCrushHouse = new Station("crush", 1, 1);

		HOME_STATION = new Station("rukn al dein", 1, 1);

		university.AddConnection(jaramana, 1, true, 1, 2, "unimana");
		jaramana.AddConnection(karajElSet, 1, true, 1, 3, "jarElSet");
		
		jaramana.AddConnection(myCrushHouse, 1, false, null, null, null);
		
		karajElSet.AddConnection(HOME_STATION, 1, true, 1, 2.5f, "karajElBeit");

		State initialState = new State(station: university, timeSpent: 0, hp: 100, money: 1500);
		Solver.Solve(initialState);
	}
}