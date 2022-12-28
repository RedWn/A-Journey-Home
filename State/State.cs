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
        // if (!isStudentRidingTheSameBus) this needs fixing for connections with null route name
        // {
        AvailableMoney += Convert.ToInt32(MathF.Ceiling(connection.GetMoneyChange()));
        // }

        TimeSpent += connection.GetTimeChange() + Station.GetWaitingTime(connection);
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

        bool isStudentRidingTheSameBus = PreviousConnection?.BusRouteName == connection.BusRouteName;

        int futureMoney = !isStudentRidingTheSameBus ? Convert.ToInt32(MathF.Ceiling(AvailableMoney + connection.GetMoneyChange())) : AvailableMoney;
        int futureHp = Convert.ToInt32(MathF.Ceiling(AvailableHP + connection.GetHPChange()));

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