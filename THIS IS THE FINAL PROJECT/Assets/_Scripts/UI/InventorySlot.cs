
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [HideInInspector] public Item item;

    [Header("Important set")]
    public bool isWeaponSlot;
    public int characterID;
    public CharacterSlots charSlot;


    [Header("Assign Objects")]
    public Button removeButton;
    public Image icon;
    [HideInInspector] public bool isOnDrag;

    public void AddItem (Item newItem)
    {
        item = newItem;
        icon.sprite = item.icon;
        icon.enabled = true;
        icon.preserveAspect = true;
        removeButton.interactable = true;
        if (isWeaponSlot)
            InventoryManager.Instance.characters[charSlot.charID].GetComponent<StatHandler>().setWeapon((WeaponItem)item);
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
        if (isWeaponSlot)
        {
            InventoryManager.Instance.characters[charSlot.charID].GetComponent<StatHandler>().setWeapon(null);
        }
    }

    public void OnRemoveButton()
    {
        if (isWeaponSlot)
        {
            InventoryManager.Instance.characters[charSlot.charID].GetComponent<StatHandler>().setWeapon(null);
            ClearSlot();
        } else
        {
            InventoryManager.Instance.RemoveItem(item);
        }
    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        isOnDrag = true;
        icon.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isOnDrag = false;
        icon.transform.localPosition = Vector3.zero;
    }


}
