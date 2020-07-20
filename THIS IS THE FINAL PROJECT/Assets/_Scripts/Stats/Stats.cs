using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
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
    public int Health = 10;
    public float mass = 1;
    public float moveSpeed;
    public float baseCoolDown = 1.0f;

    [Header("Abilities")]
    public Ability[] abilities;

    [Header("Enemy Stats")]
    public int deathExpPoint = 1;
}
