using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public static BallController instance;
    [SerializeField] private Transform[] goals;

    [SerializeField] private Transform[] balls;

    [SerializeField] private Transform target;

    [SerializeField] private float distanceToKick = 2f;
    [SerializeField] private GameObject kickButon;

    public Transform currentBall;

    public Transform currentFarthestBall;
    private Vector3 playerPosition;
    // Start is called before the first frame update

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
    void Start()
    {
        kickButon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        GetBallsNearFromPlayer();
        GetFarthestBallFromPlayer();
    }
    void Kick()
    {

    }
    void GetDistanceFromBallToPlayer()
    {

    }
    void GetBallsNearFromPlayer()
    {
        bool canKick = false;
        foreach (Transform ball in balls)
        {
            Vector3 offset = target.position - ball.position;

            if (offset.sqrMagnitude < distanceToKick * distanceToKick)
            {
                currentBall = ball;
                canKick = true;
                break;
            }

        }
        EnableKickButton(canKick);
    }
    public void GetFarthestBallFromPlayer()
    {

        float farthestBallFromPlayer = 0f;
        foreach (Transform ball in balls)
        {
            Vector3 offset = target.position - ball.position;

            if (offset.sqrMagnitude > farthestBallFromPlayer)
            {
                farthestBallFromPlayer = offset.sqrMagnitude;
                currentFarthestBall = ball;
            }

        }
    }
    public void EnableKickButton(bool isEnable)
    {
        kickButon.SetActive(isEnable);
    }

}
