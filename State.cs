class State
{
    public Station Station;

    public float TimeSpent;
    public int AvailableHP;
    public int AvailableMoney;

	public State(Station station, float timeSpent, int hp, int money)
    {
        this.Station = station;
        this.TimeSpent = timeSpent;
        this.AvailableHP = hp;
        this.AvailableMoney = money;
    }

    public void GoThroughPath(Connection connection)
    {
        this.Station = connection.TargetStation;

        this.TimeSpent += connection.GetTimeChange() + Station.GetWaitingTime(connection);
        this.AvailableHP += connection.GetHPChange();
        this.AvailableMoney += connection.GetMoneyChange();
    }

    public List<State> GetNextStates()
    {
        List<State> nextStates = new List<State>();

        foreach (Connection connection in this.Station.Connections)
        {
            if (this.canTakeConnection(connection))
            {
                State stateClone = this.Clone();
                stateClone.GoThroughPath(connection);
                nextStates.Add(stateClone);
            }
        }

        return nextStates;
    }

    private bool canTakeConnection(Connection path)
    {
        int futureMoney = this.AvailableMoney + path.GetMoneyChange();
        int futureHp = this.AvailableHP + path.GetHPChange();

        //Console.WriteLine($"Future money: {futureMoney}, Future HP: {futureHp}");

        return futureMoney >= 0 && futureHp > 0;
    }

    public bool IsFinal()
    {
        return this.Station == Program.HOME_STATION;
    }

    public State Clone()
    {
        return new State(this.Station, this.TimeSpent, this.AvailableHP, this.AvailableMoney);
    }
}