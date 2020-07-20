using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public KeyCode code;
    public Sprite icon;
    public float coolDown = 1f;

    public abstract void use();
}
