using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour 
{

    //images

    public Element elementData;
    public Card cardData;

    private Sprite cardBackground;
    private Sprite element;
    private Sprite cardSprite;

    public Image weakness;
    public Image retreatImage;
    public Image cardImage;
    public Image backgroundImage;
    public TMP_Text displayName;
    public TMP_Text health;
    //public TMP_Text retreatCost;
    public TMP_Text[] attackName;
    public TMP_Text[] attackDamage;
    public TMP_Text[] attackDescription;
    public TMP_Text[] attackCost;
    public Image[] attackElement;
    private Sprite attackElementSprite;

    private void Start()
    {
        UpdateCardDisplay();
    }
    public void UpdateCardDisplay()
    {
        elementData = cardData.element;

        displayName.text = cardData.displayName;
        health.text = cardData.hp.ToString();
        attackName[0].text = cardData.attacchi[0].name;
        attackDamage[0].text = cardData.attacchi[0].damage.ToString();
        attackDescription[0].text = cardData.attacchi[0].description;
        attackCost[0].text = cardData.attacchi[0].elementCost.ToString();
        attackElementSprite = elementData.logo;
        attackElement[0].sprite = attackElementSprite;
        attackElement[1].color = new Color(1,1,1,0);


        cardBackground = elementData.background;
        cardSprite = cardData.photo;
        

        backgroundImage.sprite = cardBackground;
        cardImage.sprite = cardSprite;


        if (cardData.attacchi[1]!=null)
        {
            attackName[1].text = cardData.attacchi[1].name;
            attackDamage[1].text = cardData.attacchi[1].damage.ToString();
            attackDescription[1].text = cardData.attacchi[1].description;
            attackCost[1].text = cardData.attacchi[1].elementCost.ToString();
            attackElement[1].sprite = attackElementSprite;
            attackElement[1].color = new Color(1, 1, 1, 1);
        }
        
    }
}
