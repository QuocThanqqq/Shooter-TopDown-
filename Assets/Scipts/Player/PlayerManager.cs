using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
     public static PlayerManager instance;

    void Awake()
    {
      if (instance != null)
      {
       Destroy(gameObject);     
      }
      else
      {
        instance = this;
      }
        DontDestroyOnLoad(gameObject);
    }
}
