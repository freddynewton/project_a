using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    [HideInInspector] public StatHandler statHandler;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        statHandler = gameObject.GetComponentInParent<StatHandler>();
    }

    private void Update()
    {
        animator.SetBool("isMoving", statHandler.isMoving);
    }
}
