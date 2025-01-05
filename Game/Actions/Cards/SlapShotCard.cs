namespace HockeySim.Game.Actions.Cards;

public class SlapShotCard : Action, ICard
{
    private const int power = 2;

    public override int Cost => 5;
    public override bool CanBeCountered => false;
    public override string Description => $"Hard slap shot (+{power} for goal making)";

    public override bool TryPlay(GameManager gameManager)
    {
        if (gameManager.TurnState.Shot == false)
            return false;
            
        gameManager.TurnState.ShotPower += power;
        return true;
    }
}
