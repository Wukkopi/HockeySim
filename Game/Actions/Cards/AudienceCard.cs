namespace HockeySim.Game.Actions.Cards;

public class AudienceCard : ICard
{
    public int Cost => 0;

    public ActionType type => ActionType.Offensive;

    public string Description => "Audience cheers (+2 energy for both teams)";

    public bool IsCounterAction => false;

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
