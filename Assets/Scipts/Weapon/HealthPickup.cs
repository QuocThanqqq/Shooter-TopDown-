using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{

    PlayerSystem playerSystem;
    public float healthRecovery;
  


    void Start()
    {
        playerSystem = FindObjectOfType<PlayerSystem>();
       
    }

    public void OnTriggerEnter(Collider other)
    {
       
        if (playerSystem.currentHealth < playerSystem.health)
        {
            playerSystem.particleHealth.Play();
            playerSystem.currentHealth = playerSystem.currentHealth + healthRecovery;
            Destroy(gameObject);
  
        }
    }
  

}
