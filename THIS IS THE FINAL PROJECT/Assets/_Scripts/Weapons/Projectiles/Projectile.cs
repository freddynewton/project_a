using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    [HideInInspector] public int damage;

    public abstract void startProjectile();

    public void destroyProjectile(float time)
    {
        // Spawn Particle effect
        Destroy(this.gameObject, time);
    }
}
