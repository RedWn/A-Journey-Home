class Program
{
    public static Station? HOME_STATION;

    public static void Main()
    {
        Station university = new Station("university", 1, 1);
        Station jaramana = new Station("jaramana", 1, 1);
        Station karajElSet = new Station("karaj el set", 1, 1);

        HOME_STATION = new Station("rukn al dein", 1, 1);

        university.AddConnection(ConnectionType.BUS, jaramana, 1, 2, "unimana");
        jaramana.AddConnection(ConnectionType.BUS, karajElSet, 1, 3, "jarElSet");
        karajElSet.AddConnection(ConnectionType.BUS, HOME_STATION, 1, 2.5f, "karajElBeit");

        State initialState = new State(station: university, timeSpent: 0, hp: 100, money: 1500);
        Solver.Solve(initialState);
    }
}