using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlots : MonoBehaviour
{
    public int charID;
    public Image profilePic;
    public Image weaponPic;
    public Text level;
    public Text charName;
    public Text weaponName;
    public Slider healthSlider;
    public Slider expSlider;
    [HideInInspector] public bool hasCharacter;

    public void changeCharacter(Sprite _profilePic,
        Sprite _weaponPic,
        int _level,
        string _charName,
        string _weaponName,
        int _maxHealth,
        int _currentHealth,
        int _maxExp,
        int _currentExp)
    {
        profilePic.sprite = _profilePic;
        profilePic.preserveAspect = true;
        weaponPic.sprite = _weaponPic;
        weaponPic.preserveAspect = true;
        level.text = _level.ToString();
        charName.text = "NAME: " + _charName;
        weaponName.text = "WEAPON: " + _weaponName;
        healthSlider.maxValue = _maxHealth;
        healthSlider.value = _currentHealth;
        expSlider.maxValue = _maxExp;
        expSlider.value = _currentExp;
        hasCharacter = true;
    }

    public void deleteCharacter()
    {
        profilePic.sprite = null;
        weaponPic.sprite = null;
        level.text = "0";
        charName.text = "NAME: ";
        weaponName.text = "WEAPON: ";
        healthSlider.maxValue = 0;
        healthSlider.value = 0;
        expSlider.maxValue = 0;
        expSlider.value = 0;
        hasCharacter = false;
    }
}
