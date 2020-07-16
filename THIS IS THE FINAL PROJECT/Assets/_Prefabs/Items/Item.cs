using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public enum ItemTypeEnum
    {
        weapon,
        usable,
        characterPart
    }

    [Header("Setup Stats")]
    public ItemTypeEnum itemType;
    new public string name = "New Item";
    public Sprite icon = null;

    [Header("Optional Setter")]
    public bool isDefaultItem = false;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
