using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float minX = -14f;
    [SerializeField] private float maxX = 14f;
    [SerializeField] private float minZ = -9f;
    [SerializeField] private float maxZ = 10f;
    private Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // lấy phím người chơi chọn
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // lấy hướng
        var moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // di chuyển 
        Vector3 newTransformPosition = transform.position + moveDirection * speed * Time.deltaTime;
        newTransformPosition.x = Mathf.Clamp(newTransformPosition.x, minX, maxX);
        newTransformPosition.z = Mathf.Clamp(newTransformPosition.z, minZ, maxZ);

        transform.position = newTransformPosition;

        if (moveDirection != Vector3.zero)
        {
            //xoay mặt theo hướng đã chọn
            transform.forward = moveDirection;
        }
        animator.SetBool("running", moveDirection != Vector3.zero);
    }
}
