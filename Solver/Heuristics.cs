class Heuristics
{
    public delegate float HeuristicCalculator(Station a, Station b);

    public static readonly HeuristicCalculator timeHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        float AVERAGE_SPEED_OF_TRANSPORTATION = 22.0f;
        float time = distance / AVERAGE_SPEED_OF_TRANSPORTATION;

        return time;
    };

    public static readonly HeuristicCalculator hpHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        float AVERAGE_HP_COST = -3.4f; // average of -10 for walking, -5 for buses, and +5 for taxis
        float dHP = distance * AVERAGE_HP_COST;

        return dHP;
    };

    public static readonly HeuristicCalculator moneyHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        float money = distance * -1000;

        return money;
    };

    public static readonly HeuristicCalculator allHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);
        float AVERAGE_HP_COST = -3.4f;
        float AVERAGE_SPEED_OF_TRANSPORTATION = 22.0f;

        //0.33 is to give all three metrics similar weights (I don't know if this is legit or habd)
        float all = distance * -1000 * 0.33f + distance * AVERAGE_HP_COST * 0.33f + distance / AVERAGE_SPEED_OF_TRANSPORTATION * 0.33f;

        return all;
    };
}
