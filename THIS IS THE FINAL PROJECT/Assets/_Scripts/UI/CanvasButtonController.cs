using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasButtonController : MonoBehaviour
{
    [Header("Canvas Objects")]
    public GameObject menuButtons;
    public GameObject inventory;
    public GameObject characterSlots;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && (!menuButtons.activeSelf && !inventory.activeSelf && !characterSlots.activeSelf))
        {

            InventoryManager.Instance.UpdateCharacters();
            setActiveCharacterSlots(!characterSlots.activeSelf);
            setActiveMenuButtons(!menuButtons.activeSelf);
            setActiveInventory(false);

           
        } else if (Input.GetKeyDown(KeyCode.Escape) || (Input.GetKeyDown(KeyCode.Tab) && (menuButtons.activeSelf || inventory.activeSelf || characterSlots.activeSelf)))
        {
            setActiveCharacterSlots(false);
            setActiveMenuButtons(false);
            setActiveInventory(false);
        }

        if (menuButtons.activeSelf || inventory.activeSelf || characterSlots.activeSelf)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void setActiveMenuButtons(bool active)
    {
        menuButtons.SetActive(active);
    }

    public void setActiveInventory(bool active)
    {
        inventory.SetActive(active);
    }

    public void setActiveCharacterSlots(bool active)
    {
        characterSlots.SetActive(active);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
