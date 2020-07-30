using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action : ScriptableObject
{
    [Header("Ability Settings")]
    public KeyCode code;
    public Sprite icon;
    public int Damage;
    public int Range;
    [Tooltip("Time to live")] public int TTL;
    public float coolDown = 1f;

    [Header("AI Settings")]
    [Range(0, 1)] public float selfDanger;
    [Range(0, 1)] public float targetProximityFear;
    [Range(0, 1)] public float targetHealth;

    public abstract void use();

    public abstract void use(UtilityAI ai);
}
