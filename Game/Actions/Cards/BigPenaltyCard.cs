namespace HockeySim.Game.Actions.Cards;

public class BigPenaltyCard : ICard
{
    public int Cost => 5;

    public string Description => "5 + 2 min penalty for opponent (-2 energy)";
    public bool IsCounterAction => false;

    public bool Play(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
