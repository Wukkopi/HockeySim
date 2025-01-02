using HockeySim.Game.Actions.Cards;

namespace HockeySim.Game;

public static class Setup
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
}
