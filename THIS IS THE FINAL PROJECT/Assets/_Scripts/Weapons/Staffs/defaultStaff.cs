using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defaultStaff : Staff
{
    public override void updateWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            leftMouseAttack();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            rightMouseAttack();
        }
    }

    public override void leftMouseAttack()
    {
        Debug.Log("Shoot");
        spawnBulletTowardsMouse();
    }

    public override void rightMouseAttack()
    {
        //
    }
}
