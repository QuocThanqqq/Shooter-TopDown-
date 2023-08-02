using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificationController : MonoBehaviour
{
    public GameObject notifi;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(ChangeScene());  
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(timer);
        Destroy(notifi);
       
    }
}
    