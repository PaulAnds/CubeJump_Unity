using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void Start()
    {
        target = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (target)
        {
            Vector3 desiredPosition = new Vector3(0, target.transform.position.y, target.transform.position.z) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}