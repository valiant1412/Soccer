using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Goal"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;

            var goal = collision.gameObject.GetComponent<GoalBehavior>();
            if (goal != null)
            {
                goal.PlayConfetti();
            }
            KickController.instance.OnReachTheGoal();
        }
    }
}
