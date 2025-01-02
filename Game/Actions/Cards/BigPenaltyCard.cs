namespace HockeySim.Game.Actions.Cards;

public class BigPenaltyCard : Action, ICard
{
    private const int energyAmount = 2;
 
    public override int Cost => 5;
    public override string Description => $"5 + 2 min penalty for opponent (-{energyAmount} energy)";
    public override bool CanBeCountered => false;
    public override bool TryPlay(GameManager gameManager) 
    {
        var opponent = gameManager.GetOpponent();
        opponent.ConsumeEnergy(energyAmount);
        return true;
    }
}
