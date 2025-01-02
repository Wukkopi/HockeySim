namespace HockeySim.Game.Player;

public class ConsolePlayer(string id, DeckManager deckManager) : Player(id, deckManager)
{
    public override void PlayCounter(GameManager manager)
    {
        throw new NotImplementedException();
    }

    public override void PlayTurn(GameManager manager)
    {
        var actions = manager.ActionManager;

        Console.WriteLine($"Energy: {EnergyBank}");
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
        Console.WriteLine($"[e]nd turn, {actions.EndTurn.Description}");
 
        while(true)
        {
            var input = Console.ReadLine();
            if (input == null)
                continue;

            var tokens = input.Split(' ');

            if (tokens.Length > 2)
                continue;

            var allowCounter = false;

            if (tokens.Length == 2)
            {
                // card actions
                var index = int.Parse(tokens[1]) - 1;
                if (index > 4) 
                    continue;

                var card = Hand[index];
                if (tokens[0] == "play")
                    allowCounter = PlayAction(card, manager);
                else if (tokens[0] == "discard")
                    AssignAsEnergy(card);
                continue;
            }

            // always available actions
            allowCounter = tokens[0] switch
            {
                "d" => PlayAction(actions.Dribble, manager),
                "p" => PlayAction(actions.Pass, manager),
                "f" => PlayAction(actions.Forecheck, manager),
                "s" => PlayAction(actions.Shoot, manager),
                "e" => PlayAction(actions.EndTurn, manager),
                "n" => PlayAction(actions.Defend, manager),
            };
        }
    }
}
