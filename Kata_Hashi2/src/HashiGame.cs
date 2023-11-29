namespace Kata_Hashi2;

public class HashiGame
{
    private readonly List<Island> _islands;
    private readonly List<Bridge> _bridges;

    public HashiGame(Solution solution)
    {
        _islands = solution.Islands;
        _bridges = solution.Bridges;

        CheckSolvability();

    }

    public bool IsSolvable { get; private set; }

    public void CheckSolvability()
    {
        IsSolvable = true;

        ValidateIslands();
    }

    private bool ValidateIslands()
    {
        var hasNoIslands = _islands.Count == 0;

        var existsAnIslandOutsideOfTheBoard = _islands
            .Any(island => island.X < 0 || island.X > 9 || island.Y < 0 || island.Y > 9);

        if (!hasNoIslands || !existsAnIslandOutsideOfTheBoard)
            return true;

        return IsSolvable = false;
    }
}