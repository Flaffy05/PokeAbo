using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
/*
public class HandManager : MonoBehaviour
{
    public GameObject cardPrefab; // assegna un prefab delle carte all'inspector
    public Transform handTransform; //Root della posizione della mano
    public float fanSpread = 5f;
    public List<GameObject> cardsInHand= new List<GameObject>(); //tiene una lista di carte nella tua mano


    void Start()
    {
      Pesca();   
      Pesca();
      Pesca();
      Pesca();
      Pesca();

    }

    public void Pesca(){
       
        GameObject newCard = Instantiate(cardPrefab, handTransform.posizione, Quaternion.identity, handTransform);
        cardsInHand.Add(newCard);

        UpdateHandVisuals();
    }
     
     private void UpdateHandVisuals(){
        int cardCount = cardsInHand.Count;
        for(int i=0; i<cardCount; i++){
            float rotationAngle=(fanSpread + (i-(cardCount-1)/2f));
            cardsInHand[i].Transform.localRotation=Quaternion.Euler(0f,0f, rotationAngle);
        }
     }


}
*/
