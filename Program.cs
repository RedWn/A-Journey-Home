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
        Station kafrsoose = new Station("Kafrsoose", 1, 1, new StationLocation(494, 273));
        HOME_STATION = kafrsoose;

        university.AddConnection(ConnectionType.BUS, grandmother_garage, university.CalcGeoDistTo(grandmother_garage), 20, "industry");
        grandmother_garage.AddConnection(ConnectionType.TAXI, coalers, grandmother_garage.CalcGeoDistTo(coalers), 45);
        grandmother_garage.AddConnection(ConnectionType.BUS, the_hardworker, grandmother_garage.CalcGeoDistTo(the_hardworker), 20, "industry");
        the_hardworker.AddConnection(ConnectionType.BUS, grandmother_garage, the_hardworker.CalcGeoDistTo(coalers), 20, "industry");
        the_hardworker.AddConnection(ConnectionType.TAXI, kafrsoose, the_hardworker.CalcGeoDistTo(kafrsoose), 45);
        coalers.AddConnection(ConnectionType.TAXI, kafrsoose, coalers.CalcGeoDistTo(kafrsoose), 45);

        State initialState = new State(station: university, timeSpent: 0, hp: 100, money: 5000);

        IComparer<StatePriority> comparer = new BestTimeGoal();
        Solver.Solve(initialState, comparer, c);
    }
}