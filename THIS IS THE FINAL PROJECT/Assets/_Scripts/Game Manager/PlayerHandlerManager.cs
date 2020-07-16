using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHandlerManager : MonoBehaviour
{
    public static PlayerHandlerManager Instance { get; private set; }
    public GameObject Character { get; set; }

    public void ChangeCharacter(GameObject character)
    {
        Character = Instantiate(character, gameObject.transform.position, Quaternion.identity, gameObject.transform) as GameObject;
        Character.name = character.name;
        InventoryManager.Instance.EquipCharacter(Character);
        GetComponent<PlayerMovement>().changeStatHandler();
        GetComponent<AbilityManager>().Abilities = Character.GetComponent<StatHandler>().abilities;
        CanvasManager.Instance.updateUI(Character);
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
}
