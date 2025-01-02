using HockeySim.Game.Actions.Cards;
using HockeySim.Game.Player;

namespace HockeySim.Game;

public static class Helper
{
    public static void Shuffle<T>(this Stack<T> stack)
    {
        var values = stack.ToArray();
        stack.Clear();
        foreach (var value in values.OrderBy(x => Random.Shared.Next()))
            stack.Push(value);
    }
    
    private static List<ICard> CreateCards<T>(int amount) where T : ICard, new()
    {
        var result = new List<ICard>(amount);
        for (var i = 0; i < amount; i++)
        {
            result.Add(new T());
        }
        return result;
    }

    public static List<ICard> BuildDeck()
    {
        var result = new List<ICard>();

        result.AddRange(CreateCards<WristShotCard>(6));
        result.AddRange(CreateCards<SlapShotCard>(5));
        result.AddRange(CreateCards<QuickPassCard>(5));
        result.AddRange(CreateCards<TimeOutCard>(3));
        result.AddRange(CreateCards<PenaltyCard>(4));
        result.AddRange(CreateCards<BigPenaltyCard>(2));
        result.AddRange(CreateCards<AudienceCard>(4));
        result.AddRange(CreateCards<FightCard>(3));
        result.AddRange(CreateCards<PassInterceptCard>(5));
        result.AddRange(CreateCards<TackleCard>(5));
        result.AddRange(CreateCards<ShieldCard>(5));
        result.AddRange(CreateCards<BlockCard>(3));

        return result;
    }

    public static bool DealEnergy(GameManager manager, int amount)
    {
        if (manager.DeckManager.CardsInDrawPile < amount * 2)
            return false;
            
        DealEnergy(manager.DeckManager, manager.Blue, amount);
        DealEnergy(manager.DeckManager, manager.Red, amount);
        return true;
    }

    public static bool DealEnergy(DeckManager deck, IPlayer player, int amount)
    {
        if (deck.CardsInDrawPile < amount)
            return false;

        ICard card;
        for(var i = 0; i < amount; i++)
        {
            deck.TryDrawCard(out card);
            player.AssignAsEnergy(card);
        }
        return true;
    }
}
