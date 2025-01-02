namespace HockeySim.Game.Actions.Cards;

public class ShieldCard : ICard
{
    public int Cost => 2;

    public bool IsCounterAction => true;

    public string Description => "Goalie blocks the shot (+1 for goal tending)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
