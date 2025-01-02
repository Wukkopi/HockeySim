namespace HockeySim.Game.Actions.Cards;

public class AudienceCard : Action, ICard
{
    private const int energyAmount = 2;
    
    public override int Cost => 0;
    public override string Description => $"Audience cheers (+{energyAmount} energy for both teams)";
    public override bool CanBeCountered => false;
    public override bool TryPlay(GameManager gameManager)
    {
        return Helper.DealEnergy(gameManager, energyAmount);
    }
}
