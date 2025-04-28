using UnityEngine;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class DeckManager : MonoBehaviour
{
    public List<Card> allCards = new List<Card>();
    private int currentIndex = 0;

    public string playerDeckName = "PileDeck"; // Nome del mazzo del player

    void Start()
    {
        Card[] cards = Resources.LoadAll<Card>("Deck_Brainrot");
        allCards.AddRange(cards);

        ShuffleDeck(); // Mischia il mazzo

        HandManager hand = FindObjectOfType<HandManager>();
        for (int i = 0; i < 5; i++)
        {
            DrawCard(hand);
        }
    }

    public void OnDeckSlotClicked()
    {
        PointerEventData pointerData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerData, results);

        foreach (RaycastResult result in results)
        {
            if (result.gameObject.name == playerDeckName)
            {
                HandManager handManager = FindObjectOfType<HandManager>();
                if (handManager != null)
                {
                    DrawCard(handManager);
                }
                return;
            }
        }

        Debug.Log("Non puoi pescare da questo mazzo!");
    }

    public void DrawCard(HandManager handManager)
    {
        if (allCards.Count == 0 || currentIndex >= allCards.Count)
        {
            Debug.Log("No more cards in the deck.");
            return;
        }

        Card nextCard = allCards[currentIndex];
        handManager.Pesca(nextCard);

        currentIndex++;
    }

    private void ShuffleDeck()
    {
        for (int i = 0; i < allCards.Count; i++)
        {
            int randomIndex = Random.Range(i, allCards.Count);
            Card temp = allCards[i];
            allCards[i] = allCards[randomIndex];
            allCards[randomIndex] = temp;
        }
    }
}





