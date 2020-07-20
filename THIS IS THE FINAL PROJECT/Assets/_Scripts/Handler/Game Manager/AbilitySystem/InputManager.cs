using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager), typeof(AnimatorHandler), typeof(WeaponHandlerPlayer))]
public class InputManager : MonoBehaviour
{
    [HideInInspector] public StatHandler statHandler;
    [HideInInspector] public Rigidbody2D rb;

    private Vector2 inputVector;
    private Camera mainCamera;
    private float coolDownTikker;


    private void Start()
    {
        statHandler = gameObject.GetComponent<StatHandler>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    public bool CheckIfCooldownIsOver()
    {
        if (coolDownTikker >= 0)
        {
            coolDownTikker -= Time.deltaTime;
        } else
        {
            return true;
        }

        return false;
    }

    private void Update()
    {
        if (!statHandler.isEnemy)
        {
            movementInputs();
            if (CheckIfCooldownIsOver())
            {
                abilitiesInputs();
            }
            move();
            LookAtMouse();
        } else
        {

        }
    }

    private void abilitiesInputs()
    {
        foreach (Ability ability in statHandler.stats.abilities)
        {
            if (Input.GetKeyDown(ability.code))
            {
                ability.use();
                coolDownTikker = statHandler.stats.baseCoolDown + ability.coolDown;
            }
        }
    }

    private void movementInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 mouseMpos = Input.mousePosition;
        inputVector = new Vector2(moveX, moveY).normalized;

        if (inputVector != Vector2.zero)
            statHandler.isMoving = true;
        else
            statHandler.isMoving = false;
    }

    private void move()
    {
        // Check if the payer can move
        if (!statHandler.canInteract)
        {
            rb.velocity = inputVector * statHandler.stats.moveSpeed;

        }
    }

    private void LookAtMouse()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (worldPos.x <= gameObject.transform.position.x)
            statHandler.GFX.transform.rotation = Quaternion.Slerp(statHandler.GFX.transform.rotation, Quaternion.Euler(0, -180, 0), 0.1f);
        else
            statHandler.GFX.transform.rotation = Quaternion.Slerp(statHandler.GFX.transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
    }
}
