using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform playerPosition;

    public Transform target;

    public Vector3 offset;

    void Start()
    {
        SetPlayer();
        offset = transform.position - target.position;
    }
    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
    public void SetPlayer()
    {
        target = playerPosition;
    }
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
