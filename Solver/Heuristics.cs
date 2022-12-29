class Heuristics
{
    public delegate float HeuristicCalculator(Station a, Station b);

    public static readonly HeuristicCalculator timeHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        float MINIMUM_SPEED_OF_TRANSPORTATION = 5.5f;
        float time = distance / MINIMUM_SPEED_OF_TRANSPORTATION;

        return time;
    };

    public static readonly HeuristicCalculator hpHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        float HP_COST = -10f;
        float dHP = distance * HP_COST;

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
        float HP_COST = -10f;
        float MINIMUM_SPEED_OF_TRANSPORTATION = 5.5f;

        //0.33 is to give all three metrics similar weights (I don't know if this is legit or habd)
        float all = distance * -1000 * 0.33f + distance * HP_COST * 0.33f + distance / MINIMUM_SPEED_OF_TRANSPORTATION * 0.33f;

        return all;
    };
}
