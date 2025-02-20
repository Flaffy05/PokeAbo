using UnityEngine;

[CreateAssetMenu(fileName = "Status", menuName = "Scriptable Objects/Status")]
public class Status : ScriptableObject
{
    public int turns;
    public int damage;
    public string description;
    public Sprite icon;
}
