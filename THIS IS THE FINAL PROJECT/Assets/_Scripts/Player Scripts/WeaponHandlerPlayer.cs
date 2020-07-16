using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandlerPlayer : MonoBehaviour
{
    [HideInInspector] public StatHandler stat;
    [HideInInspector] public Weapon weaponScript;

    private void Update()
    {
        if (stat.WeaponObject != null)
        {
            weaponScript.updateWeapon();
        }
    }

    private void Start()
    {
        stat = gameObject.GetComponent<StatHandler>();
    }

    private void FixedUpdate()
    {
        if (stat.WeaponObject != null)
        {
            lookAtMouse();
        }
    }

    private void lookAtMouse()
    { 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (worldPos - gameObject.transform.position).normalized;
        Vector3 newHandpos = gameObject.transform.position + (dir * .5f);
        newHandpos.z *= -1f;
        stat.WeaponObject.transform.position = Vector3.Lerp(stat.WeaponObject.transform.position, newHandpos, 0.3f);
    }
}
