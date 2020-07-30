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
    private float globalCD;
    private float spaceCD;
    private float fCD;
    private float rCD;
    private float qCD;
    private float weaponCD;

    private void Start()
    {
        statHandler = gameObject.GetComponent<StatHandler>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        tickCD();

        if (!statHandler.isEnemy)
        {
            movementInputs();
            abilitiesInputs();
            move();
            LookAtMouse();
        }
    }

    private void abilitiesInputs()
    {
        qSkill();
        fSkill();
        rSkill();
        spaceSkill();
    }

    public void qSkill()
    {
        if (qCD <= 0 && statHandler.stats.qAction != null && Input.GetKeyDown(statHandler.stats.qAction.code))
        {
            statHandler.stats.qAction.use();
            qCD += statHandler.stats.qAction.coolDown;
            setGlobalCD();
        }
    }

    public void fSkill()
    {
        if (fCD <= 0 && statHandler.stats.fAction != null && Input.GetKeyDown(statHandler.stats.fAction.code))
        {
            statHandler.stats.fAction.use();
            fCD += statHandler.stats.fAction.coolDown;
            setGlobalCD();
        }
    }

    public void rSkill()
    {
        if (rCD <= 0 && statHandler.stats.rAction != null && Input.GetKeyDown(statHandler.stats.rAction.code))
        {
            statHandler.stats.rAction.use();
            rCD += statHandler.stats.rAction.coolDown;
            setGlobalCD();
        }
    }

    public void spaceSkill()
    {
        if (spaceCD <= 0 && statHandler.stats.spacebarAction != null && Input.GetKeyDown(statHandler.stats.spacebarAction.code))
        {
            statHandler.stats.spacebarAction.use();
            spaceCD += statHandler.stats.spacebarAction.coolDown;
            setGlobalCD();
        }
    }

    private void tickCD()
    {
        if (globalCD > 0)
            globalCD -= Time.deltaTime;
        if (fCD > 0)
            fCD -= Time.deltaTime;
        if (rCD > 0)
            rCD -= Time.deltaTime;
        if (qCD > 0)
            qCD -= Time.deltaTime;
        if (spaceCD > 0)
            spaceCD -= Time.deltaTime;
        if (weaponCD > 0)
            weaponCD -= Time.deltaTime;
    }

    private void setGlobalCD()
    {
        globalCD += statHandler.stats.baseCoolDown;
        spaceCD += statHandler.stats.baseCoolDown;
        fCD += statHandler.stats.baseCoolDown;
        rCD += statHandler.stats.baseCoolDown;
        qCD += statHandler.stats.baseCoolDown;
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
