using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Animator), typeof(AnimatorHandler), typeof(WeaponHandlerPlayer))]
public class StatHandler : MonoBehaviour
{
    public enum RarityEnum
    {
        common,
        uncommon,
        rare,
        epic,
        legendary
    }

    [Header("Default Stats")]
    public RarityEnum rarity;
    public bool isEnemy = true;
    public Ability[] abilities;
    public int Health = 10;
    public float mass = 1;
    public float moveSpeed;

    [Header("Default Assign")]
    public GameObject GFX;
    public WeaponItem Weapon;
    [HideInInspector] public GameObject WeaponObject;

    [Header("Enemy Stats")]
    public int deathExpPoint = 1;

    //Hide Public vars
    [HideInInspector] public int currentHealth;
    [HideInInspector] public int level = 1;
    [HideInInspector] public int exPoints;
    [HideInInspector] public int maxExpPoints = 20;


    // Hide Public Booleans
    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isDead;
    [HideInInspector] public bool canInteract;

    // Scripts
    [HideInInspector] public WeaponHandlerPlayer weaponHandler;
    [HideInInspector] public AnimatorHandler animatorHandler;

    [Header("Dash Effect")]
    public float dashSpeed;
    public float startDashTime;
    public ParticleSystem dashParticleSystem;
    [HideInInspector] public float dashTime;

    private void Start()
    {
        weaponHandler = GetComponent<WeaponHandlerPlayer>();
        animatorHandler = GetComponent<AnimatorHandler>();

        currentHealth = Health;

        if (level == 0)
            level++;
    }

    private void Awake()
    {
        dashTime = startDashTime;
        currentHealth = Health;

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
