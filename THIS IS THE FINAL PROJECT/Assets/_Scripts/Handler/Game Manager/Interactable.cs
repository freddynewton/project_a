using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;

    private bool hasInteracted = false;


    private void FixedUpdate()
    {
        if (!hasInteracted && Vector3.Distance(PlayerHandlerManager.Instance.Character.transform.position, gameObject.transform.position) < radius)
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
