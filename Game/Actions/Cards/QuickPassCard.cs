namespace HockeySim.Game.Actions.Cards;

public class QuickPassCard : ICard
{
    public int Cost => 2;
    
    public bool IsCounterAction => false;

    public string Description => "Make a fast pass (prevents interception)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
