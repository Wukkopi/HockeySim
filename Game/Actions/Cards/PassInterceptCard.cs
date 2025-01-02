namespace HockeySim.Game.Actions.Cards;

public class PassInterceptCard : ICard
{
    public int Cost => 2;

    public bool IsCounterAction => true;

    public string Description => "Intercepts a regular pass";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
