using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public enum WeaponTypeEnum
    {
        range,
        melee
    }

    [Header("Important must assign")]
    public Item item;

    [Header("Stats")]
    public WeaponTypeEnum weaponType;
    public int damage;
    public int armorPenetration;
    public float attackRate;

    [Header("GameObjects")]
    public GameObject firePoint;

    [HideInInspector] public float attackRateTimer;

    public abstract void updateWeapon();

    public bool checkIfAttackRateTimerIsDone()
    {
        attackRateTimer -= Time.deltaTime;

        if (attackRateTimer <= 0)
        {
            attackRateTimer = attackRate;
            return true;
        }
        return false;
    }

    public void startTimer()
    {

    }

    public abstract void leftMouseAttack();

    public abstract void rightMouseAttack();


}
