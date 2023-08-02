using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FlashController : MonoBehaviour
{
    public ParticleSystem particle;
    public void Fire()
    {
        particle.Simulate(0, true, true);
        particle.Play();

    }
}
