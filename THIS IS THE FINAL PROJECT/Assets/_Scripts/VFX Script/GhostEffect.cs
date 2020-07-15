using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEffect : MonoBehaviour
{
    public float delay;
    public float delayDestroy = 1;
    private float ghostDelaySeconds;
    [HideInInspector] public bool makeGhost = false;
    public GameObject ghost;

    // Start is called before the first frame update
    void Start()
    {
        ghostDelaySeconds = delay;
    }

    // Update is called once per frame
    void Update()
    {
        if (makeGhost)
        {
            if (ghostDelaySeconds > 0)
                ghostDelaySeconds -= Time.deltaTime;
            else
            {
                //Generate a ghost
                GameObject currentGhost = Instantiate(ghost, transform.position, transform.rotation);
                currentGhost.GetComponent<SpriteRenderer>().sprite = GetComponent<SpriteRenderer>().sprite;
                ghostDelaySeconds = delay;
                Destroy(currentGhost, delayDestroy);
            }
        }
    }
}
