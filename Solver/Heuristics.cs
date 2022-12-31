class Heuristics
{
    public delegate float HeuristicCalculator(Station a, Station b);

    private static readonly float HIGHEST_HP_COST = 5f;
    private static readonly float FASTEST_TRANSPORTATION_SPEED = 45f;
    private static readonly float HIGHEST_MONEY_COST_PER_KM = 0f;

    public static readonly HeuristicCalculator timeHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        float time = distance / FASTEST_TRANSPORTATION_SPEED;

        return time;
    };

    public static readonly HeuristicCalculator hpHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);
        float dHP = distance * HIGHEST_HP_COST;

        return dHP;
    };

    public static readonly HeuristicCalculator moneyHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);
        float money = distance * HIGHEST_MONEY_COST_PER_KM;

        return money;
    };

    public static readonly HeuristicCalculator allHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        return distance;
    };
}
