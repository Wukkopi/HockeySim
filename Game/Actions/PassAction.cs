namespace HockeySim.Game.Actions;

public class PassAction : Action
{
    private const int power = 1;

    public override int Cost => 3;
    public override bool CanBeCountered => true;

    public override string Description => $"Passes the puck forwards by one area (+{power} boost for goal making)";

    public override bool TryPlay(GameManager gameManager)
    {
        gameManager.TurnState.ShotPower += power;
        gameManager.Puck.MoveForward();
        return true;
    }
}
