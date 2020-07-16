using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Item", menuName = "Inventory/WeaponItem")]
public class WeaponItem : Item
{
    [Header("Weapon Game Object")]
    public GameObject Weapon;
}
