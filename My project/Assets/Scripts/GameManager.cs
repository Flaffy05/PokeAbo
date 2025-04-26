using UnityEngine;

public class GameManager : MonoBehaviour
{
    /*public enum Turn { Player, Opponent }
    public Turn currentTurn;

    public DeckManager deckManager;
    public HandManager playerHandManager;

    private bool playerHasDrawn = false;

    void Start()
    {
        currentTurn = Turn.Player;
    }

    void Update()
    {
        switch (currentTurn)
        {
            case Turn.Player:
                break;

            case Turn.Opponent:
                OpponentTurn();
                break;
        }
    }

    // Gestisce il turno del giocatore
    public void PlayerTurn()
    {
        if (!playerHasDrawn)
        {
            deckManager.DrawCard(playerHandManager, "Player"); // Pesca dal mazzo del giocatore
            playerHasDrawn = true;
        }
        else
        {
            Debug.Log("Hai già pescato una carta questo turno!");
        }
    }

    // Gestisce il turno dell'IA (avversario)
    private void OpponentTurn()
    {
        Debug.Log("Turno dell'IA!");
        deckManager.DrawCard(null, "Opponent"); // Pesca dal mazzo dell'avversario senza usare HandManager
        currentTurn = Turn.Player; // Passa il turno al giocatore
        playerHasDrawn = false; // Resetta la pesca del giocatore per il prossimo turno
    }

    // Metodo chiamato quando il giocatore finisce il suo turno
    public void OnEndPlayerTurnClicked()
    {
        if (currentTurn == Turn.Player)
        {
            Debug.Log("Fine del turno del giocatore.");
            currentTurn = Turn.Opponent;

            // Resetta la possibilità di pesca per il giocatore
            deckManager.EndTurn();
            playerHasDrawn = false;
        }
    }*/
}



