class Program
{
    public static Station? HOME_STATION;


    public static void Main()
    {
        Station university = new Station("University", 5 / 60, 20 / 60, new StationLocation(496, 321));
        Station grandmother_garage = new Station("Grandmother Garage", 10 / 60, 5 / 60, new StationLocation(501, 308));
        Station the_hardworker = new Station("The Hardworker", 2 / 60, 30 / 60, new StationLocation(500, 295));
        Station coalers = new Station("Coalers", 2 / 60, 2 / 60, new StationLocation(508, 294)); ;
        Station tartar_blasphemy = new Station("Tartar Blasphemy", 2, 10 / 60, new StationLocation(494, 273));
        Station president_bridge = new Station("The President Bridge", 10 / 60, 15 / 60, new StationLocation(512, 288));
        Station the_square = new Station("Ummayyad Square", 10 / 60, 20 / 60, new StationLocation(513, 276));
        Station immigrants = new Station("The Immigrants", 10 / 60, 20 / 60, new StationLocation(521, 273));
        Station corn_square = new Station("Corn Square", 15 / 60, 25 / 60, new StationLocation(521, 290));
        Station the_garden = new Station("The Garden", 15 / 60, 25 / 60, new StationLocation(521, 282));
        Station religon_corner = new Station("Religion's Corner", 20 / 60, 30 / 60, new StationLocation(531, 296));
        Station consolation = new Station("Consolation", 10 / 60, 30 / 60, new StationLocation(511, 262));
        Station beautiful_woman = new Station("Beautiful Woman", 2 / 60, 20 / 60, new StationLocation(500, 252));
        Station project_destroyed = new Station("Project Destroyed", 2 / 60, 15 / 60, new StationLocation(531, 240));

        university.AddConnection(ConnectionType.BUS, grandmother_garage, university.CalcGeoDistTo(grandmother_garage), 20, "industry");
        grandmother_garage.AddConnection(ConnectionType.TAXI, coalers, grandmother_garage.CalcGeoDistTo(coalers), 40);
        grandmother_garage.AddConnection(ConnectionType.BUS, the_hardworker, grandmother_garage.CalcGeoDistTo(the_hardworker), 20, "industry");
        the_hardworker.AddConnection(ConnectionType.BUS, grandmother_garage, the_hardworker.CalcGeoDistTo(coalers), 20, "industry");
        the_hardworker.AddConnection(ConnectionType.TAXI, tartar_blasphemy, the_hardworker.CalcGeoDistTo(tartar_blasphemy), 40);
        the_hardworker.AddConnection(ConnectionType.TAXI, the_square, the_hardworker.CalcGeoDistTo(the_square), 40);
        the_hardworker.AddConnection(ConnectionType.TAXI, beautiful_woman, the_hardworker.CalcGeoDistTo(beautiful_woman), 40);
        coalers.AddConnection(ConnectionType.TAXI, tartar_blasphemy, coalers.CalcGeoDistTo(tartar_blasphemy), 40);
        coalers.AddConnection(ConnectionType.BUS, president_bridge, coalers.CalcGeoDistTo(president_bridge), 20, "industry");
        president_bridge.AddConnection(ConnectionType.BUS, the_square, president_bridge.CalcGeoDistTo(the_square), 20, "shitty");
        president_bridge.AddConnection(ConnectionType.BUS, the_garden, president_bridge.CalcGeoDistTo(the_garden), 20, "industry");
        president_bridge.AddConnection(ConnectionType.TAXI, corn_square, president_bridge.CalcGeoDistTo(corn_square), 40);
        tartar_blasphemy.AddConnection(ConnectionType.TAXI, the_square, tartar_blasphemy.CalcGeoDistTo(the_square), 40);
        the_square.AddConnection(ConnectionType.BUS, immigrants, the_square.CalcGeoDistTo(immigrants), 20, "circler");
        the_square.AddConnection(ConnectionType.BUS, consolation, the_square.CalcGeoDistTo(consolation), 20, "shitty");
        the_garden.AddConnection(ConnectionType.TAXI, corn_square, the_garden.CalcGeoDistTo(corn_square), 40);
        the_garden.AddConnection(ConnectionType.BUS, immigrants, the_garden.CalcGeoDistTo(immigrants), 20, "industry");
        corn_square.AddConnection(ConnectionType.TAXI, religon_corner, the_garden.CalcGeoDistTo(religon_corner), 40);
        immigrants.AddConnection(ConnectionType.BUS, religon_corner, the_garden.CalcGeoDistTo(religon_corner), 20, "circler");
        immigrants.AddConnection(ConnectionType.TAXI, project_destroyed, the_garden.CalcGeoDistTo(project_destroyed), 40);
        consolation.AddConnection(ConnectionType.TAXI, beautiful_woman, the_garden.CalcGeoDistTo(beautiful_woman), 40);
        consolation.AddConnection(ConnectionType.BUS, project_destroyed, the_garden.CalcGeoDistTo(project_destroyed), 20, "shitty");
        beautiful_woman.AddConnection(ConnectionType.BUS, consolation, the_garden.CalcGeoDistTo(consolation), 20, "circler");

        State initialState = new State(station: university, timeSpent: 0, hp: 100, money: 5000);
        HOME_STATION = immigrants;

        Heuristics.HeuristicCalculator c = Heuristics.timeHeuristic;
        IComparer<StatePriority> comparer = new BestTimeGoal();
        Solver.Solve(initialState, comparer, c);
    }
}