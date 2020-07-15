using System;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public bool isPulsing = true;

    private void Start()
    {
        item.icon = gameObject.GetComponent<SpriteRenderer>().sprite;
    }

    public override void Interact()
    {
        base.Interact();

        pickUp();
    }

    private void pickUp()
    {
        Debug.Log("Picking up " + item.name);
        if (InventoryManager.Instance.AddItem(item))
            Destroy(gameObject);
    }
}
