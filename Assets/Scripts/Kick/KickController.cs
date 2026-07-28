using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickController : MonoBehaviour
{
    public static KickController instance;
    [SerializeField] private Transform[] goals;

    [SerializeField] private float ballSpeed = 2f;

    [SerializeField] private float reachNearestGoal = 1f;
    private bool isBallRunning = false;

    [SerializeField] private GameObject kickButon;

    [SerializeField] private CameraController cameraController;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void Kick()
    {
        if (!isBallRunning && BallController.instance.currentBall != null)
        {
            Transform currentBall = BallController.instance.currentBall;
            StartCoroutine(KickBallToGoal(currentBall));
        }
    }
    IEnumerator KickBallToGoal(Transform currentBall)
    {
        isBallRunning = true;
        kickButon.SetActive(false);
        cameraController.SetTarget(currentBall);
        if (currentBall != null)
        {
            Rigidbody ballrb = currentBall.GetComponent<Rigidbody>();
            if (ballrb != null)
            {
                ballrb.isKinematic = true;

                Transform nearestGoal = GetNearestGoal(currentBall);
                // set van toc
                while ((currentBall.position - nearestGoal.position).sqrMagnitude > reachNearestGoal * reachNearestGoal)
                {
                    currentBall.position = Vector3.MoveTowards(currentBall.position, nearestGoal.position, ballSpeed * Time.deltaTime);
                    yield return null;
                }

                if (ballrb != null)
                {
                    ballrb.isKinematic = false;
                }
            }
            isBallRunning = false;
        }

    }
    Transform GetNearestGoal(Transform currentBall)
    {
        Transform nearestGoal = null;
        float nearestDistance = float.MaxValue;
        foreach (Transform goal in goals)
        {
            Vector3 offset = currentBall.position - goal.position;
            if (offset.sqrMagnitude < nearestDistance)
            {
                nearestDistance = offset.sqrMagnitude;
                nearestGoal = goal;
            }
        }
        return nearestGoal;
    }
    public void AutoKick()
    {
        Transform farthestBall = BallController.instance.currentFarthestBall;
        if (!isBallRunning && farthestBall != null)
        {
            StartCoroutine(KickBallToGoal(farthestBall));
        }
    }

    public void OnReachTheGoal()
    {
        StartCoroutine(ReturnCameraToPlayer());
    }
    public IEnumerator ReturnCameraToPlayer()
    {
        yield return new WaitForSeconds(2f);
        cameraController.SetPlayer();
    }
}
