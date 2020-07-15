using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StatHandler : MonoBehaviour
{
    public enum Rarity {
        common,
        uncommon,
        rare,
        epic,
        legendary
    }

    [Header("Default Stats")]
    public Rarity rarity;
    public Ability[] abilities;
    public int Health = 10;
    public float moveSpeed;

    [Header("Default Assign")]
    public GameObject GFX;
    public GameObject Hand;
    public Item Weapon;

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


    [Header("Dash Effect")]
    public float dashSpeed;
    public float startDashTime;
    public ParticleSystem dashParticleSystem;
    [HideInInspector] public float dashTime;

    private void Start()
    {
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

    public void setWeapon(Item item)
    {
        Weapon = item;
    }
}
