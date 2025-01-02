namespace HockeySim.Game.Actions.Cards;

public class PenaltyCard : Action, ICard
{
    private const int energy = 1;
    
    public override int Cost => 3;
    public override bool CanBeCountered => false;
    public override string Description => $"A 2 minute penalty for opponent (-{energy} energy)";

    public override bool TryPlay(GameManager gameManager)
    {
        throw new NotImplementedException();
    }
}
