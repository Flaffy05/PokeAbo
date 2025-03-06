using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class DeckManager : MonoBehaviour
{
   public List<Card> allCards = new List<Card>();

   private int currentIndex=0;

   void Start(){
    Card[] cards=Resources.LoadAll<Card>("Deck_Droidi");

    allCards.AddRange(cards);

    HandManager hand=FindObjectOfType<HandManager>();
    for(int i=0;i<5;i++){
        DrawCard(hand);
    }
   }

   public void DrawCard(HandManager handManager){
    if (allCards.Count==0){

        return;
    }
        Card nextCard=allCards[currentIndex];
        handManager.Pesca(nextCard);
        currentIndex=(currentIndex+1)%allCards.Count;
   }
}
