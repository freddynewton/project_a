using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Staff : Weapon
{
    [Header("Staff Stats")]

    [Header("Projectile")]
    public GameObject bullet;
    public float bulletLifeDuration;
    public float bulletSpeed;

    public void spawnBulletTowardsMouse()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (worldPos - gameObject.transform.position).normalized;

        GameObject b = Instantiate(bullet, firePoint.transform.position, Quaternion.identity, null) as GameObject;
        Projectile p = b.GetComponent<Projectile>();
        p.damage = damage;
        b.GetComponent<Rigidbody2D>().AddForce(dir * bulletSpeed, ForceMode2D.Impulse);
        p.destroyProjectile(bulletLifeDuration);
    }

}
