using HockeySim.Game.Actions;
using HockeySim.Game.Actions.Cards;

namespace HockeySim.Game.Player;

public abstract class Player(string id, DeckManager deckManager) : IPlayer
{
    private readonly DeckManager deckManager = deckManager;
    public string ID { get; } = id;
    public int Goals { get; set; }
    public List<ICard> Energy = new();
    public List<ICard> Hand = new();

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

    public bool PlayAction(IAction action, GameManager manager)
    {
        ConsumeEnergy(action.Cost);
        if (action is ICard)
        {
            deckManager.Discard((ICard)action);
        }
        return action.TryPlay(manager);
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

    public abstract void PlayTurn(GameManager manager);
    public abstract void PlayCounter(GameManager manager);
}
