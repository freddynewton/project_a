using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [HideInInspector] public GameObject player { get; private set; }
    public List<GameObject> characters;
    [HideInInspector] public GameObject weapon { get; private set; }

    // Delegates
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnCharacterChanged();
    public OnCharacterChanged onCharacterChangedCallback;

    [Header("Inventory")]
    public List<Item> items = new List<Item>();
    public int itemSlots = 20;

    [Header("Game Objects")]
    public GameObject defaultChar;

    public bool AddItem(Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= itemSlots)
            {
                return false;
            }
            items.Add(item);

            if (onItemChangedCallback != null)
                onItemChangedCallback.Invoke();
        }
        return true;
    }

    public void RemoveItem(Item item)
    {
        items.Remove(item);

        if (onItemChangedCallback != null)
            onItemChangedCallback.Invoke();
    }

    public void UpdateCharacters()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            StatHandler statHandler = characters[i].GetComponent<StatHandler>();

            string weaponName = "";
            if (statHandler.Weapon != null)
                weaponName = statHandler.Weapon.name;

            CanvasManager.Instance.Characters[i].changeCharacter(statHandler.GFX.GetComponent<SpriteRenderer>().sprite,
                statHandler.level,
                statHandler.name,
                weaponName,
                statHandler.stats.Health,
                statHandler.currentHealth,
                statHandler.maxExpPoints,
                statHandler.exPoints);
        }
    }

    public void EquipCharacter(GameObject character)
    {
        if (!characters.Contains(character) && characters.Count < 3)
        {
            character.GetComponent<StatHandler>().isEnemy = false;
            characters.Add(character);
        }
    }

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
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

        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        if (characters.Count == 0)
        {
            PlayerHandlerManager.Instance.ChangeCharacter(defaultChar);
        }
    }
}
