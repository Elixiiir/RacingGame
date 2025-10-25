using UnityEngine;

[CreateAssetMenu(fileName = "baseItem", menuName = "ScriptableObjects/item")]
public class SOitem : ScriptableObject
{
    public int id;
    public string nameItem;
    public Sprite Icon;
}
