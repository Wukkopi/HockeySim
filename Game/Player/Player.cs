using System.Runtime.InteropServices;
using HockeySim.Game.Actions;
using HockeySim.Game.Actions.Cards;

namespace HockeySim.Game.Player;

public abstract class Player(string id, DeckManager deckManager) : IPlayer
{
    private readonly DeckManager deckManager = deckManager;
    public string ID { get; } = id;
    public int Goals { get; set; }
    public List<ICard> Energy { get; } = new();
    public List<ICard> Hand { get; }= new();

    public int EnergyBank => Energy.Count;

    public void AssignAsEnergy(ICard card)
    {
        Energy.Add(card);
        Hand.Remove(card);
    }

    public void ConsumeEnergy(int amount)
    {
        for (var i = 0; i < amount; i++)
        {
            deckManager.Discard(Energy[0]);
            Energy.Remove(Energy[0]);
        }
    }

    public bool TryPlayAction(IAction action, GameManager manager, out bool canBeCountered)
    {
        canBeCountered = action.CanBeCountered;
        if (!action.CanAfford(this))
            return false;

        if (!action.TryPlay(manager))
            return false;

        ConsumeEnergy(action.Cost);
        if (action is ICard)
        {
            deckManager.Discard((ICard)action);
        }
        return true;
    }

    public bool DrawCards()
    {
        while(Hand.Count < Settings.CardsInHand)
        {
            if(!deckManager.TryDrawCard(out var card))
            {
                return false;
            }
            Hand.Add(card);
        }
        return true;
    }

    public bool TryGetCardInHand<T>(out ICard? card) where T : ICard
    {
        card = null;
        foreach (var c in Hand)
        {
            if (c.GetType() == typeof(T))
            {
                card = c;
                return true;
            }
        }
        return false;
    }

    public abstract void PlayTurn(GameManager manager);
    public abstract void PlayCounter(GameManager manager);
}
