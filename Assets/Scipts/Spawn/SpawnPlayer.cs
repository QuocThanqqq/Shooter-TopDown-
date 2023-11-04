using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    
    public GameObject player;
    
    void Start()
    {
        SpawnPlayerS();
    }

    public void SpawnPlayerS()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
