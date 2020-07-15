using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 deiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, deiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
