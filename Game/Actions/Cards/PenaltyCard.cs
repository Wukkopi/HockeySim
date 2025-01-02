namespace HockeySim.Game.Actions.Cards;

public class PenaltyCard : ICard
{
    public int Cost => 3;

    public bool IsCounterAction => false;

    public string Description => "A 2 minute penalty for opponent (-1 energy)";

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
