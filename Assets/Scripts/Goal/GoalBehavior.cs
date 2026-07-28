using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehavior : MonoBehaviour
{
    [SerializeField] private ParticleSystem confetti;

    public void PlayConfetti()
    {
        if (confetti != null)
        {
            confetti.Play();
        }
    }
}
