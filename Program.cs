class Program
{
    public static Station? HOME_STATION;
    public static void Main()
    {
        Station University = new Station("University", 5 / 60, 20 / 60, new StationLocation(496, 321));
        Station GrandmotherGarage = new Station("Grandmother Garage", 10 / 60, 5 / 60, new StationLocation(501, 308));
        Station TheHardworker = new Station("The Hardworker", 2 / 60, 30 / 60, new StationLocation(500, 295));
        Station Coalers = new Station("Coalers", 2 / 60, 2 / 60, new StationLocation(508, 294)); ;

        Station TartarBlasphemy = new Station("Tartar Blasphemy", 2, 10 / 60, new StationLocation(494, 273));
        Station PresidentBridge = new Station("The President Bridge", 10 / 60, 15 / 60, new StationLocation(512, 288));
        Station UmayyadSquare = new Station("Ummayyad Square", 10 / 60, 20 / 60, new StationLocation(513, 276));

        Station Immigrants = new Station("The Immigrants", 10 / 60, 20 / 60, new StationLocation(521, 273));
        Station CornSquare = new Station("Corn Square", 15 / 60, 25 / 60, new StationLocation(521, 290));
        Station TheGarden = new Station("The Garden", 15 / 60, 25 / 60, new StationLocation(521, 282));
        Station ReligionCorner = new Station("Religion's Corner", 20 / 60, 30 / 60, new StationLocation(531, 296));

        Station Consolation = new Station("Consolation", 10 / 60, 30 / 60, new StationLocation(511, 262));
        Station BeautifulWoman = new Station("Beautiful Woman", 2 / 60, 20 / 60, new StationLocation(500, 252));

        Station ProjectDestroyed = new Station("Project Destroyed", 2 / 60, 15 / 60, new StationLocation(531, 240));

        University.AddConnection(ConnectionType.BUS, GrandmotherGarage, University.CalcGeoDistTo(GrandmotherGarage), 20, "industry");

        GrandmotherGarage.AddConnection(ConnectionType.TAXI, Coalers, GrandmotherGarage.CalcGeoDistTo(Coalers), 40);
        GrandmotherGarage.AddConnection(ConnectionType.BUS, TheHardworker, GrandmotherGarage.CalcGeoDistTo(TheHardworker), 20, "industry");

        TheHardworker.AddConnection(ConnectionType.BUS, GrandmotherGarage, TheHardworker.CalcGeoDistTo(Coalers), 20, "industry");
        TheHardworker.AddConnection(ConnectionType.TAXI, TartarBlasphemy, TheHardworker.CalcGeoDistTo(TartarBlasphemy), 40);
        TheHardworker.AddConnection(ConnectionType.TAXI, UmayyadSquare, TheHardworker.CalcGeoDistTo(UmayyadSquare), 40);
        TheHardworker.AddConnection(ConnectionType.TAXI, BeautifulWoman, TheHardworker.CalcGeoDistTo(BeautifulWoman), 40);

        Coalers.AddConnection(ConnectionType.TAXI, TartarBlasphemy, Coalers.CalcGeoDistTo(TartarBlasphemy), 40);
        Coalers.AddConnection(ConnectionType.BUS, PresidentBridge, Coalers.CalcGeoDistTo(PresidentBridge), 20, "industry");

        PresidentBridge.AddConnection(ConnectionType.BUS, UmayyadSquare, PresidentBridge.CalcGeoDistTo(UmayyadSquare), 20, "shitty");
        PresidentBridge.AddConnection(ConnectionType.BUS, TheGarden, PresidentBridge.CalcGeoDistTo(TheGarden), 20, "industry");
        PresidentBridge.AddConnection(ConnectionType.TAXI, CornSquare, PresidentBridge.CalcGeoDistTo(CornSquare), 40);

        TartarBlasphemy.AddConnection(ConnectionType.TAXI, UmayyadSquare, TartarBlasphemy.CalcGeoDistTo(UmayyadSquare), 40);

        UmayyadSquare.AddConnection(ConnectionType.BUS, Immigrants, UmayyadSquare.CalcGeoDistTo(Immigrants), 20, "circler");
        UmayyadSquare.AddConnection(ConnectionType.BUS, Consolation, UmayyadSquare.CalcGeoDistTo(Consolation), 20, "shitty");

        TheGarden.AddConnection(ConnectionType.TAXI, CornSquare, TheGarden.CalcGeoDistTo(CornSquare), 40);
        TheGarden.AddConnection(ConnectionType.BUS, Immigrants, TheGarden.CalcGeoDistTo(Immigrants), 20, "industry");

        CornSquare.AddConnection(ConnectionType.TAXI, ReligionCorner, TheGarden.CalcGeoDistTo(ReligionCorner), 40);

        Immigrants.AddConnection(ConnectionType.BUS, ReligionCorner, TheGarden.CalcGeoDistTo(ReligionCorner), 20, "circler");
        Immigrants.AddConnection(ConnectionType.TAXI, ProjectDestroyed, TheGarden.CalcGeoDistTo(ProjectDestroyed), 40);

        Consolation.AddConnection(ConnectionType.TAXI, BeautifulWoman, TheGarden.CalcGeoDistTo(BeautifulWoman), 40);
        Consolation.AddConnection(ConnectionType.BUS, ProjectDestroyed, TheGarden.CalcGeoDistTo(ProjectDestroyed), 20, "shitty");

        BeautifulWoman.AddConnection(ConnectionType.BUS, Consolation, TheGarden.CalcGeoDistTo(Consolation), 20, "circler");

        State initialState = new State(station: University, timeSpent: 0, hp: 50, money: 5000);
        HOME_STATION = ProjectDestroyed;

        Heuristics.HeuristicCalculator h = Heuristics.hpHeuristic;
        IComparer<StatePriority> comparer = new BestHPGoal();

        Solver.Solve(initialState, comparer, h);
    }
}