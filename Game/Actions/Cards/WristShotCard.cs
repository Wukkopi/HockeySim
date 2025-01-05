namespace HockeySim.Game.Actions.Cards;

public class WristShotCard : Action, ICard
{
    private const int power = 1;
    public override int Cost => 3;
    public override bool CanBeCountered => false;
    public override string Description => $"Make a wristshot (+{power} for goal making)";

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.TurnState.Shot == false)
            return false;
            
        gameManager.TurnState.ShotPower += power;
        return true;
    }
}
