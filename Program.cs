class Program
{
    public static Station? HOME_STATION;


    public static void Main()
    {
        Heuristics.HeuristicCalculator c = Heuristics.timeHeuristic;

        Station university = new Station("University", 5 / 60, 20 / 60, new StationLocation(496, 321));
        Station grandmother_garage = new Station("Grandmother Garage", 10 / 60, 5 / 60, new StationLocation(501, 308));
        Station the_hardworker = new Station("The Hardworker", 2 / 60, 30 / 60, new StationLocation(500, 295));
        Station coalers = new Station("Coalers", 2 / 60, 2 / 60, new StationLocation(508, 294));
        Station kafrsoose = new Station("Kafrsoose", 2, 10 / 60, new StationLocation(494, 273));
        Station president_bridge = new Station("The President Bridge", 10 / 60, 15 / 60, new StationLocation(512, 288));
        Station the_square = new Station("Ummayyad Square", 10 / 60, 20 / 60, new StationLocation(513, 276));
        Station immigrants = new Station("The Immigrants", 10 / 60, 20 / 60, new StationLocation(521, 273));
        HOME_STATION = immigrants;

        university.AddConnection(ConnectionType.BUS, grandmother_garage, university.CalcGeoDistTo(grandmother_garage), 20, "industry");
        grandmother_garage.AddConnection(ConnectionType.TAXI, coalers, grandmother_garage.CalcGeoDistTo(coalers), 40);
        grandmother_garage.AddConnection(ConnectionType.BUS, the_hardworker, grandmother_garage.CalcGeoDistTo(the_hardworker), 20, "industry");
        the_hardworker.AddConnection(ConnectionType.BUS, grandmother_garage, the_hardworker.CalcGeoDistTo(coalers), 20, "industry");
        the_hardworker.AddConnection(ConnectionType.TAXI, kafrsoose, the_hardworker.CalcGeoDistTo(kafrsoose), 40);
        the_hardworker.AddConnection(ConnectionType.TAXI, the_square, the_hardworker.CalcGeoDistTo(the_square), 40);
        coalers.AddConnection(ConnectionType.TAXI, kafrsoose, coalers.CalcGeoDistTo(kafrsoose), 40);
        coalers.AddConnection(ConnectionType.BUS, president_bridge, coalers.CalcGeoDistTo(president_bridge), 20, "industry");
        president_bridge.AddConnection(ConnectionType.BUS, the_square, president_bridge.CalcGeoDistTo(the_square), 20, "shitty");
        kafrsoose.AddConnection(ConnectionType.TAXI, the_square, kafrsoose.CalcGeoDistTo(the_square), 40);
        the_square.AddConnection(ConnectionType.BUS, immigrants, the_square.CalcGeoDistTo(immigrants), 20, "circler");

        State initialState = new State(station: university, timeSpent: 0, hp: 100, money: 5000);

        IComparer<StatePriority> comparer = new BestTimeGoal();
        Solver.Solve(initialState, comparer, c);
    }
}