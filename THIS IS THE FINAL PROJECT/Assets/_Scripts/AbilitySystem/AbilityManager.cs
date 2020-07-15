using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    [HideInInspector] public Ability[] Abilities { get; set; }

    private void Update()
    {
        foreach (Ability ability in Abilities)
        {
            if (Input.GetKeyDown(ability.code))
            {
                ability.activate();
            }
        }
    }
}
