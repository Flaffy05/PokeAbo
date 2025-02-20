
using System;
using UnityEngine;
using System.IO;
using UnityEngine.Rendering.LookDev;

[CreateAssetMenu(fileName = "Pokemons new card", menuName = "Scriptable Objects/Card")]
public class Card : ScriptableObject
{
    private static int cardIcCount = 0;
    public int cardId = ++cardIcCount;
    public Element element;
    public Status status;
    public string displayName;
    public int hp;
    
    public Sprite photo;

    public attack[] attacchi;
    
    //public Element cardElement;
    //Element attackElement;

}

[System.Serializable]
public class attack {
    public string name = "";
    public int damage = 0;
    //public Element attackElement;
    public string description;
    public int elementCost;
    public string enflictStatus;
    //public SpecialEffect SpecialEffect;

}

