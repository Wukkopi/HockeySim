using HockeySim.Game;

var gameManager = new GameManager();

while (true)
{
    gameManager.PrintState();
    gameManager.InTurn.PlayTurn(gameManager);
}

return 0;