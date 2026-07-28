using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KickController : MonoBehaviour
{
    public static KickController instance;
    [SerializeField] private Transform[] goals;

    [SerializeField] private Transform[] balls;

    [SerializeField] private Transform target;

    [SerializeField] private float distanceToKick = 2f;
    [SerializeField] private GameObject kickButon;

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
                canKick = true;
                break;
            }

        }
        EnableKickButton(canKick);
    }
    public void EnableKickButton(bool isEnable)
    {
        kickButon.SetActive(isEnable);
    }
}
