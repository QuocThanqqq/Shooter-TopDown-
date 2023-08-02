using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DnaPickup : MonoBehaviour
{
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            PlayerSystem.numberDNA++;
            
            Destroy(gameObject);
        }
    }

   
}

