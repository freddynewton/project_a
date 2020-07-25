using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Settings")]
public class AISettings : ScriptableObject
{
    [Header("Health Curves")]
    public AnimationCurve selfDanger;
    public AnimationCurve targetProximityFear;
    public AnimationCurve targetHealth;

    [Header("Settings")]
    public float maxRange;
}
