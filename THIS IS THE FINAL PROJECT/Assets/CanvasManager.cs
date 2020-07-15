using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CanvasManager : MonoBehaviour, IDropHandler
{
    [Header("Hud Elements")]
    public Image profilePic;
    public Text levelCounter;
    public Slider healthSlider;
    public Slider expSlider;

    [Header("Attack Elements")]
    public Image weaponPic;
    public GameObject[] abilityButtons;

    [Header("Inventory")]
    public GameObject inventoryUI;
    public Transform itemsParent;
    public InventorySlot[] weaponSlots;
    [HideInInspector] public InventorySlot[] slots;
    [HideInInspector] public InventoryManager inventory;

    [Header("Character")]
    public CharacterSlots[] Characters;


    public static CanvasManager Instance { get; private set; }
    public GameObject Char { get; private set; }
    public StatHandler statHandler { get; private set; }

    public void updateUI(GameObject character)
    {
        Char = character;
        statHandler = character.GetComponent<StatHandler>();
        profilePic.sprite = statHandler.GFX.GetComponent<SpriteRenderer>().sprite;
        profilePic.preserveAspect = true;

        healthSlider.maxValue = statHandler.Health;
        expSlider.maxValue = 100;

        updateAbilitiesUI();
    }

    private void Start()
    {
        inventory = InventoryManager.Instance;
        inventory.onItemChangedCallback += updateInventoryUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    private void updateInventoryUI()
    {
        Debug.Log("Update Inventory UI");
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);

            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }

    public void updateWeaponUI(GameObject weapon)
    {

    }

    private void updateAbilitiesUI()
    {

    }

    public void updateCharacters()
    {
        updateAbilitiesUI();

    }

    private void Update()
    {


        if (Char != null && statHandler != null)
        {
            levelCounter.text = statHandler.level.ToString();
            healthSlider.value = statHandler.currentHealth;
            expSlider.value = statHandler.exPoints;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        foreach (InventorySlot itemHolder in slots)
        {
            RectTransform rect = itemHolder.gameObject.transform as RectTransform;

            InventorySlot destSlot = rect.gameObject.GetComponent<InventorySlot>();
            Item destItem = destSlot.item;
            InventorySlot startSlot = null;
            Item startItem = null;

            foreach (InventorySlot dragItem in slots)
            {
                if (dragItem.isOnDrag)
                {
                    startSlot = dragItem;
                    startItem = dragItem.item;
                }
            }

            if (startSlot == null)
            {
                foreach (InventorySlot dragItem in weaponSlots)
                {
                    if (dragItem.isOnDrag && startSlot == null)
                    {
                        startSlot = dragItem;
                        startItem = dragItem.item;
                    }
                }
            }

            if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
            {
                if (startItem == null)
                    break;

                if (destItem == null)
                {
                    
                    destSlot.AddItem(startItem);
                    startSlot.ClearSlot();
                    if (startSlot.isWeaponSlot)
                        InventoryManager.Instance.AddItem(startItem);
                }
                else
                {
                    destSlot.ClearSlot();
                    startSlot.ClearSlot();

                    destSlot.AddItem(startItem);
                    startSlot.AddItem(destItem);
                    if (startSlot.isWeaponSlot)
                    {
                        InventoryManager.Instance.RemoveItem(startItem);
                        InventoryManager.Instance.AddItem(destItem);
                    }
                }
            }
        }

        foreach (InventorySlot weaponHolder in weaponSlots)
        {
            RectTransform rect = weaponHolder.gameObject.transform as RectTransform;

            InventorySlot destSlot = rect.gameObject.GetComponent<InventorySlot>();
            Item destItem = destSlot.item;
            InventorySlot startSlot = null;
            Item startItem = null;

            foreach (InventorySlot dragItem in slots)
            {
                if (dragItem.isOnDrag)
                {
                    startSlot = dragItem;
                    startItem = dragItem.item;
                }
            }

            if (startSlot == null)
            {
                foreach (InventorySlot dragItem in weaponSlots)
                {
                    if (dragItem.isOnDrag && startSlot == null)
                    {
                        startSlot = dragItem;
                        startItem = dragItem.item;
                    }
                }
            }

            if (RectTransformUtility.RectangleContainsScreenPoint(rect, Input.mousePosition))
            {
                if (startItem == null)
                    break;

                else if (!destSlot.charSlot.hasCharacter)
                    continue;

                // give weaponslot item 
                if (destItem == null)
                {
                   
                    destSlot.AddItem(startItem);
                    startSlot.ClearSlot();
                    if (startSlot.isWeaponSlot == false)
                        InventoryManager.Instance.RemoveItem(startItem);
                        
                    break;
                }
                else
                {
                    destSlot.ClearSlot();
                    startSlot.ClearSlot();

                    destSlot.AddItem(startItem);
                    startSlot.AddItem(destItem);
                    if (destSlot.isWeaponSlot == false)
                    {
                        InventoryManager.Instance.RemoveItem(destItem);
                        InventoryManager.Instance.AddItem(startItem);
                    }
                    break;
                }
            }
        }
    }
}
