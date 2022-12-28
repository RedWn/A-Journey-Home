class Heuristics
{
    public delegate float HeuristicCalculator(Station a, Station b);

    public static readonly HeuristicCalculator timeHeuristic = (a, b) =>
    {
        float distance = a.CalcGeoDistTo(b);

        float MEAN_SPEED_OF_VEHICLE_TRANSPORTATION = 22.0f;
        float time = distance / MEAN_SPEED_OF_VEHICLE_TRANSPORTATION;

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

        float money = distance * -1000; //TODO: get a reasonable number to put here 

        return money;
    };
}
