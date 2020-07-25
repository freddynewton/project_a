using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StatHandler : MonoBehaviour
{
    [Header("Scriptable Objects")]
    public Stats stats;

    [Header("Default Stats")]
    public bool isEnemy = true;

    // Objects
    [HideInInspector] public GameObject GFX;
    [HideInInspector] public WeaponItem Weapon;
    [HideInInspector] public GameObject WeaponObject;
    [HideInInspector] public GameObject Target;

    // Scripts
    [HideInInspector] public WeaponHandlerPlayer weaponHandler;
    [HideInInspector] public AnimatorHandler animatorHandler;

    //Hide Public vars
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int level = 1;
    [HideInInspector] public int exPoints;
    [HideInInspector] public int maxExpPoints = 20;


    // Hide Public Booleans
    [HideInInspector] public bool isMoving = false;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool canInteract = true;
    [HideInInspector] public bool isAiming = false;
    [HideInInspector] public bool isAttacking = false;

    private void Start()
    {
        weaponHandler = gameObject.GetComponent<WeaponHandlerPlayer>();
        animatorHandler = gameObject.GetComponent<AnimatorHandler>();
        GFX = gameObject;
    }

    private void Awake()
    {
        currentHealth = stats.Health;

        if (level == 0)
            level++;
    }

    public void GetDamge(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);
        }
    }

    public void setWeapon(WeaponItem item)
    {
        if (item == null)
        {
            Destroy(WeaponObject);
            weaponHandler.weaponScript = null;
            Weapon = null;
            return;
        }
        if (item.itemType == Item.ItemTypeEnum.weapon)
        {
            Weapon = item;
            WeaponObject = Instantiate(Weapon.Weapon, gameObject.transform.position, Quaternion.identity, gameObject.transform) as GameObject;
            weaponHandler.weaponScript = WeaponObject.GetComponent<Weapon>();
        }
    }
}
