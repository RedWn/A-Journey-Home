class State
{
    public Station Station;

    public float TimeSpent;
    public int AvailableHP;
    public int AvailableMoney;

    public Connection? PreviousConnection = null;

    public State(Station station, float timeSpent, int hp, int money)
    {
        Station = station;
        TimeSpent = timeSpent;
        AvailableHP = hp;
        AvailableMoney = money;
    }

    public void GoThroughPath(Connection connection)
    {
        Station = connection.TargetStation;

        bool isStudentRidingTheSameBus = PreviousConnection?.BusRouteName == connection.BusRouteName;
        if (!isStudentRidingTheSameBus)
        {
            AvailableMoney += connection.GetMoneyChange();
        }

        TimeSpent += connection.GetTimeChange() + Station.GetWaitingTime(connection);
        AvailableHP += connection.GetHPChange();

        PreviousConnection = connection;
    }

    public Tuple<List<State>, List<Connection>> GetNextMoves()
    {
        List<State> nextStates = new();
        List<Connection> nextConnections = new();

        foreach (Connection connection in Station.Connections)
        {
            if (canTakeConnection(connection))
            {
                State stateClone = Clone();
                stateClone.GoThroughPath(connection);
                nextStates.Add(stateClone);
                nextConnections.Add(connection);
            }
        }

        return Tuple.Create(nextStates, nextConnections);
    }

    private bool canTakeConnection(Connection connection)
    {

        bool isStudentRidingTheSameBus = PreviousConnection?.BusRouteName == connection.BusRouteName;

        int futureMoney = !isStudentRidingTheSameBus ? AvailableMoney + connection.GetMoneyChange() : AvailableMoney;
        int futureHp = AvailableHP + connection.GetHPChange();

        //Console.WriteLine($"Future money: {futureMoney}, Future HP: {futureHp}");

        return futureMoney >= 0 && futureHp > 0;
    }

    public bool IsFinal()
    {
        return Station == Program.HOME_STATION;
    }

    public State Clone()
    {
        return new State(Station, TimeSpent, AvailableHP, AvailableMoney);
    }
}