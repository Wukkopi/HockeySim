namespace HockeySim.Game.Actions;

public class ShootAction : Action
{
    private const int power = 1;
    public override int Cost => 4;
    public override bool CanBeCountered => true;
    public override string Description => $"Try to shoot a goal (+{power} for shooting)";
    public override bool TryPlay(GameManager gameManager)
    {
        gameManager.TurnState.ShotPower += power;
        gameManager.TurnState.Shot = true;
        return true;
    }
}
