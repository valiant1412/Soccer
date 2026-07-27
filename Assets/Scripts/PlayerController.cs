using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // lấy phím người chơi chọn
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // lấy hướng
        var moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // di chuyển 
        transform.position += moveDirection * speed * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            //xoay mặt theo hướng đã chọn
            transform.forward = moveDirection;
        }
    }
}
