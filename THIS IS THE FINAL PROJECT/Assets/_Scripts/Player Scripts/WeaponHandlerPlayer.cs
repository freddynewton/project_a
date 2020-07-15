using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandlerPlayer : MonoBehaviour
{
    private GameObject hand;

    // [Header("Weapons")]
    [HideInInspector] public GameObject equipedWeapon;
    private Weapon weaponScript;

    private void Start()
    {
        // equipWeapon(Resources.Load("Prefabs/Weapons/default_staff") as GameObject);
    }

    private void Update()
    {
        if (equipedWeapon != null)
        {
            weaponScript.updateWeapon();
        }
    }

    private void FixedUpdate()
    {
        if (hand != null)
        {
            lookAtMouse();
        }
    }

    public void changeHand(GameObject handObject)
    {
        if (handObject == null)
        {
            Destroy(hand);
        }
        else
        {
            hand = Instantiate(handObject, gameObject.transform.position, Quaternion.identity, gameObject.transform) as GameObject;

        }
    }

    public void equipWeapon(GameObject weapon)
    {
        if (equipedWeapon != null)
            GameObject.Destroy(equipedWeapon);

        GameObject w = Instantiate(weapon, hand.transform);
        equipedWeapon = w;
        weaponScript = equipedWeapon.GetComponent<Weapon>();
    }

    private void lookAtMouse()
    { 
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = (worldPos - gameObject.transform.position).normalized;
        Vector3 newHandpos = gameObject.transform.position + (dir * .5f);
        newHandpos.z *= -1f;
        hand.transform.position = Vector3.Lerp(hand.transform.position, newHandpos, 0.3f);
    }
}
