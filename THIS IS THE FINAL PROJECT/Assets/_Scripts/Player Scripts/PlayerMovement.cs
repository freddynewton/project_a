using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GhostEffect ghost;

    private Vector2 inputVector;
    private Camera mainCamera;

    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public StatHandler statHandler;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (statHandler != null)
        {
            InputProcess();
            //Dash();
            LookAtMouse();
            move();
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

    /*
    private void Dash()
    {
        if (statHandler.dashTime <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            // Player is dashing
            ghost.makeGhost = true;
            statHandler.dashParticleSystem.Play();
            statHandler.canInteract = true;
            var tempInputVec = inputVector;
            rb.velocity = tempInputVec * statHandler.dashSpeed;
            
            // rb.AddForce(inputVector * statHandler.dashSpeed, ForceMode2D.Impulse);
            statHandler.dashTime = 0.1f;
        }
        else
        {
            statHandler.dashTime -= Time.deltaTime;
            if (statHandler.dashTime <= 0)
            {
                ghost.makeGhost = false;
                statHandler.dashParticleSystem.Stop();
                // Dashing is over and player is no longer dashing
                statHandler.canInteract = false;
            }
        }
    }

    */

    private void InputProcess()
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
        // Check if the payer is dashing
        if (!statHandler.canInteract)
        {
            rb.velocity = inputVector * statHandler.stats.moveSpeed;
           // rb.MovePosition(rb.position + inputVector * statHandler.moveSpeed * Time.deltaTime);
        }
    }
}