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
    private Sprite CardWeakness;
    private Element CardWeaknessElement;

    public Image weakness;
    public Image retreatImage;
    public Image cardImage;
    public Image backgroundImage;
    public TMP_Text displayName;
    public TMP_Text health;
    public TMP_Text retreatCost;
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
        if(elementData.colorWhite){
            displayName.color=new Color(255,255,255,255);
            health.color=new Color(255,255,255,255);
            retreatCost.color=new Color(255,255,255,255);
            attackName[0].color=new Color(255,255,255,255);
            attackDamage[0].color=new Color(255,255,255,255);
            attackDescription[0].color=new Color(255,255,255,255);
            attackCost[0].color=new Color(255,255,255,255);
            attackName[1].color=new Color(255,255,255,255);
            attackDamage[1].color=new Color(255,255,255,255);
            attackDescription[1].color=new Color(255,255,255,255);
            attackCost[1].color=new Color(255,255,255,255); 
        }

        displayName.text = cardData.displayName;
        retreatCost.text=cardData.reatreatCost.ToString();
        health.text = cardData.hp.ToString();
        attackName[0].text = cardData.attacchi[0].name;
        attackDamage[0].text = cardData.attacchi[0].damage.ToString();
        attackDescription[0].text = cardData.attacchi[0].description;
        attackCost[0].text = cardData.attacchi[0].elementCost.ToString();
        attackElementSprite = elementData.logo;
        attackElement[0].sprite = attackElementSprite;
        attackElement[1].color = new Color(1,1,1,0);

        CardWeaknessElement=elementData.weakness;
        CardWeakness = CardWeaknessElement.logo;
        cardBackground = elementData.background;
        cardSprite = cardData.photo;
        
        
        weakness.sprite=CardWeakness;
        backgroundImage.sprite = cardBackground;
        cardImage.sprite = cardSprite;
        retreatImage.sprite=attackElementSprite; 


        if (cardData.attacchi.Length>1)
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
