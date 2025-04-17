using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();
    private int currentIndex = 0;

    void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Deck_Brainrot");
        allCards.AddRange(cards);

        HandManager hand = FindObjectOfType<HandManager>();
        for (int i = 0; i < 5; i++)
        {
            DrawCard(hand);
        }
    }

    public void OnDeckSlotClicked()
    {
        HandManager handManager = FindObjectOfType<HandManager>();
        if (handManager != null)
        {
            DrawCard(handManager);
        }
    }

    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0 || currentIndex >= allCards.Count) // Controllo se il mazzo è vuoto
        {
            Debug.Log("No more cards in the deck.");
            return; // Non pesca più carte se il mazzo è vuoto
        }

        Card nextCard = allCards[currentIndex];
        handManager.Pesca(nextCard);

        currentIndex++; // Avanza al prossimo indice
    }
}




