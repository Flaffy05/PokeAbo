using UnityEngine;

[CreateAssetMenu(fileName = "Element", menuName = "Scriptable Objects/Element")]
public class Element : ScriptableObject
{
    public Element weakness;
    public Sprite background;
    public Sprite logo;
    public bool colorWhite;  // 1 white, 0 black
}