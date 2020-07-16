using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    [HideInInspector] public Transform player;
    private bool hasInteracted = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        if (!hasInteracted && Vector3.Distance(player.position, gameObject.transform.position) < radius)
        {
            isInRange();
        }
    }

    public virtual void Interact()
    {
        // this method need to be overwritten
        Debug.Log("Interacting with " + transform);
    }

    private void isInRange()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            hasInteracted = true;
            Interact();
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
