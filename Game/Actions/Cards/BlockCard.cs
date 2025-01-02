namespace HockeySim.Game.Actions.Cards;

public class BlockCard : ICard
{
    public int Cost => 4;

    public bool IsCounterAction => true;

    public string Description => "Goalie blocks the shot (+2 for goal tending)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
