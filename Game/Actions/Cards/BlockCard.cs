namespace HockeySim.Game.Actions.Cards;

public class BlockCard : Action, ICard
{
    private const int power = 2;

    public override int Cost => 4;
    public override bool CanBeCountered => false;
    public override string Description => $"Goalie blocks the shot (+{power} for goal tending)";

    public override bool TryPlay(GameManager gameManager)
    {
        gameManager.TurnState.ShotPower -= power;
        return true;
    }
}
