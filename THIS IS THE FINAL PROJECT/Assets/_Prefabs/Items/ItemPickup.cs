using System;
using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public bool isPulsing = true;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = item.icon;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
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
