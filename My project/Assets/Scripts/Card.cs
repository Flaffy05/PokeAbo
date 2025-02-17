using UnityEngine;


[CreateAssetMenu(fileName = "Pokemons new card", menuName = "Standard Card")]
public class Card : ScriptableObject
{
    
    public int cardId;
    public string displayName = "";
    public int hp = 0;
    
    public Sprite photo;

    public attack[] attacchi;
    
    public Element cardElement;
    //Element attackElement;

}

[System.Serializable]
public class attack {
        public string name = "";
        public int damage = 0;
        public Element attackElement;
        public string description;
        public int elementCost;

}
    
    public enum Element {Erba, Fuoco, Acqua, Elettro, Oscurità, Lotta, Neutro, Metallo, Luce}; 
public enum Status {Avvelenato, Stunnato, Stanco, Normale};  //booooooh
