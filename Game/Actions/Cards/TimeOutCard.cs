namespace HockeySim.Game.Actions.Cards;

public class TimeOutCard : ICard
{
    public int Cost => 4;
    public bool IsCounterAction => false;

    public string Description => "Coach calls for timeout (draws 2 cards)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
