namespace HockeySim.Game.Actions.Cards;

public class ShieldCard : Action, ICard
{
    private const int power = 1;

    public override int Cost => 2;
    public override bool CanBeCountered => false;
    public override string Description => $"Goalie blocks the shot (+{power} for goal tending)";

    public override bool TryPlay(GameManager gameManager)
    {
        gameManager.TurnState.ShotPower -= power;
        return true;
    }
}
