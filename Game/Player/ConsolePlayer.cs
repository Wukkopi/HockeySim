using HockeySim.Game.Actions.Cards;

namespace HockeySim.Game.Player;

public class ConsolePlayer(string id, DeckManager deckManager) : Player(id, deckManager)
{
    public override void PlayCounter(GameManager manager)
    {
        var actions = manager.ActionManager;

        ICard? interceptCard = null;
        ICard? tackleCard = null;
        ICard? blockCard = null;
        ICard? shieldCard = null;

        if (manager.TurnState.Passed && TryGetCardInHand<PassInterceptCard>(out interceptCard))
            Console.WriteLine($"[i]ntercept (card in hand) Cost: {interceptCard.Cost}, {interceptCard.Description}");
        if (manager.TurnState.Dribbled && TryGetCardInHand<TackleCard>(out tackleCard))
            Console.WriteLine($"[t]ackle (card in hand) Cost: {tackleCard.Cost}, {tackleCard.Description}");
        if (manager.TurnState.Shot && TryGetCardInHand<BlockCard>(out blockCard))
            Console.WriteLine($"[b]lock (card in hand) Cost: {blockCard.Cost}, {blockCard.Description}");
        if (manager.TurnState.Shot && TryGetCardInHand<ShieldCard>(out shieldCard))
            Console.WriteLine($"[s]hield (card in hand) Cost: {shieldCard.Cost}, {shieldCard.Description}");
        if (manager.TurnState.Shot)
            Console.WriteLine($"[d]efend Cost: {actions.Defend.Cost}, {actions.Defend.Description}");
        Console.WriteLine($"[e]nd countering");
        Console.WriteLine();

        while(true)
        {
            Console.WriteLine($"Energy: {EnergyBank}");
            var input = Console.ReadLine();

            if (input == null)
                continue;

            if (input == "i" && interceptCard != null)
                TryPlayAction(interceptCard, manager);
            if (input == "t" && tackleCard != null)
                TryPlayAction(tackleCard, manager);
            if (input == "b" && blockCard != null)
                TryPlayAction(blockCard, manager);
            if (input == "s" && shieldCard != null)
                TryPlayAction(shieldCard, manager);
            if (input == "d")
                TryPlayAction(actions.Defend, manager);
            if (input == "e")
                break;
        }
    }

    public void PrintTurnOptions(GameManager manager)
    {
        var actions = manager.ActionManager;

        manager.PrintState();

        Console.WriteLine("'play <n>' to play card n, discard <n> to convert card into energy");
        for (var i = 0; i < Hand.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] Cost: {Hand[i].Cost} {Hand[i].GetType().Name}, {Hand[i].Description}");
        }
        if (manager.Puck.Owner == this)
        {
            Console.WriteLine($"[d]ribble Cost: {actions.Dribble.Cost}, {actions.Dribble.Description}");
            Console.WriteLine($"[p]ass Cost: {actions.Pass.Cost}, {actions.Pass.Description}");
            Console.WriteLine($"[s]hoot Cost: {actions.Shoot.Cost}, {actions.Shoot.Description}");
        }
        else
        {
            Console.WriteLine($"[f]orecheck Cost: {actions.Forecheck.Cost}, {actions.Forecheck.Description}");
        }
        Console.WriteLine($"[e]nd action");
        Console.WriteLine($"[q]uit");
        Console.WriteLine();
        
        Console.WriteLine($"Energy: {EnergyBank}");
    }

    public override void PlayTurn(GameManager manager)
    {
        var actions = manager.ActionManager;

        while(manager.InTurn == this)
        {
            PrintTurnOptions(manager);           

            var input = Console.ReadLine();
            if (input == null)
                continue;

            var tokens = input.Split(' ');

            var successful = false;

            if (tokens.Length >= 2 && Hand.Count > 0)
            {
                // card actions
                var index = int.Parse(tokens[1]) - 1;
                if (index > 4)
                    continue;

                var card = Hand[index];
                if (tokens[0] == "play")
                    successful = TryPlayAction(card, manager);
                else if (tokens[0] == "discard")
                    AssignAsEnergy(card);
            }
            else
            {
                if (tokens[0] == "e")
                    break;
                if (tokens[0] == "q")
                    Environment.Exit(0);

                // always available actions
                successful = tokens[0] switch
                {
                    "d" => TryPlayAction(actions.Dribble, manager),
                    "p" => TryPlayAction(actions.Pass, manager),
                    "f" => TryPlayAction(actions.Forecheck, manager),
                    "s" => TryPlayAction(actions.Shoot, manager),
                    "n" => TryPlayAction(actions.Defend, manager),
                    _ => false,
                };
            }
            if (!successful)
                continue;

        }
        
        TryPlayAction(actions.EndTurn, manager);
    }
}
