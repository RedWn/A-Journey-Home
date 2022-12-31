class State
{
    public Station Station;

    public float TimeSpentInHours;

    public int AvailableHP;
    public int AvailableMoney;

    public Connection? PreviousConnection = null;

    public State(Station station, float timeSpent, int hp, int money)
    {
        Station = station;
        TimeSpentInHours = timeSpent;
        AvailableHP = hp;
        AvailableMoney = money;
    }

    private bool isStudentRidingTheSameBus(Connection nextConnection)
    {
        bool previousAndNextConnectionsAreBuses = nextConnection.Type == ConnectionType.BUS && PreviousConnection?.Type == ConnectionType.BUS;

        return previousAndNextConnectionsAreBuses && PreviousConnection?.BusRouteName == nextConnection.BusRouteName;
    }

    public void GoThroughPath(Connection connection)
    {
        Station = connection.TargetStation;

        if (!isStudentRidingTheSameBus(connection))
        {
            AvailableMoney += Convert.ToInt32(MathF.Ceiling(connection.GetMoneyChange()));
            TimeSpentInHours += Station.GetWaitingTime(connection);
        }

        TimeSpentInHours += connection.GetTimeChange();
        AvailableHP += Convert.ToInt32(MathF.Ceiling(connection.GetHPChange()));

        PreviousConnection = connection;
    }

    public List<State> GetNextStates()
    {
        List<State> nextStates = new();

        foreach (Connection connection in Station.Connections)
        {
            if (canTakeConnection(connection))
            {
                State stateClone = Clone();
                stateClone.GoThroughPath(connection);
                nextStates.Add(stateClone);
            }
        }

        return nextStates;
    }

    private bool canTakeConnection(Connection connection)
    {
        int futureMoney = AvailableMoney;

        if (!isStudentRidingTheSameBus(connection))
        {
            futureMoney += Convert.ToInt32(MathF.Ceiling(connection.GetMoneyChange()));
        }

        int futureHp = AvailableHP + Convert.ToInt32(MathF.Ceiling(connection.GetHPChange()));

        //Console.WriteLine($"Future money: {futureMoney} \t\t Future HP: {futureHp} \t\t Target Station: {connection.TargetStation.Name}");

        return futureMoney >= 0 && futureHp > 0;
    }

    public bool IsFinal()
    {
        return Station == Program.HOME_STATION;
    }

    public State Clone()
    {
        return new State(Station, TimeSpentInHours, AvailableHP, AvailableMoney)
        {
            PreviousConnection = this.PreviousConnection
        };
    }
    public string GetHash()
    {
        return String.Concat(Station.Name, TimeSpentInHours, AvailableHP, AvailableMoney);
    }
}