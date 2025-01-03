namespace HockeySim.Game.Actions;

public class DefendAction : Action
{
    private const int power = 1;

    public override int Cost => 2;

    public override string Description => $"Defend the goal (+{power} for defense)";

    public override bool CanBeCountered => false;

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.TurnState.ShotPower == 0)
            return false;
        
        gameManager.TurnState.ShotPower -= power;
        return true;
    }
}
