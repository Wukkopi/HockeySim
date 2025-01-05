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
                TryPlayAction(interceptCard, manager, out _);
            if (input == "t" && tackleCard != null)
                TryPlayAction(tackleCard, manager, out _);
            if (input == "b" && blockCard != null)
                TryPlayAction(blockCard, manager, out _);
            if (input == "s" && shieldCard != null)
                TryPlayAction(shieldCard, manager, out _);
            if (input == "d")
                TryPlayAction(actions.Defend, manager, out _);
            if (input == "e")
                break;
        }
    }

    public override void PlayTurn(GameManager manager)
    {
        var actions = manager.ActionManager;

        var allowCounter = false;
        
        while(manager.InTurn == this)
        {
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
            Console.WriteLine();

            var counterEnabled = false;
            while (true)
            {
                Console.WriteLine($"Energy: {EnergyBank}");
                var input = Console.ReadLine();
                if (input == null)
                    continue;

                var tokens = input.Split(' ');

                var successful = false;

                if (tokens.Length >= 2)
                {
                    // card actions
                    var index = int.Parse(tokens[1]) - 1;
                    if (index > 4)
                        continue;

                    var card = Hand[index];
                    if (tokens[0] == "play")
                        successful = TryPlayAction(card, manager, out allowCounter);
                    else if (tokens[0] == "discard")
                        AssignAsEnergy(card);
                }
                else
                {
                    if (tokens[0] == "e")
                        break;

                    // always available actions
                    successful = tokens[0] switch
                    {
                        "d" => TryPlayAction(actions.Dribble, manager, out allowCounter),
                        "p" => TryPlayAction(actions.Pass, manager, out allowCounter),
                        "f" => TryPlayAction(actions.Forecheck, manager, out allowCounter),
                        "s" => TryPlayAction(actions.Shoot, manager, out allowCounter),
                        "n" => TryPlayAction(actions.Defend, manager, out allowCounter),
                        _ => false,
                    };
                }
                if (!successful)
                    continue;
                counterEnabled |= allowCounter;
            }

            if (counterEnabled)
                manager.GetOpponent().PlayCounter(manager);
            
            Console.WriteLine($"[e]nd turn, {actions.EndTurn.Description}");
            Console.WriteLine("anything else to continue");

            var input2 = Console.ReadLine();
            if (input2 == "e")
                break;
        }
        
        TryPlayAction(actions.EndTurn, manager, out _);
    }
}
