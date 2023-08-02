using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocal : MonoBehaviour
{

    public GameObject health;
    void Start()
    {
        Instantiate(health, transform.position, Quaternion.identity);
    }

 
}

