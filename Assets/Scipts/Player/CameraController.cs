
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public GameObject player;
   public Transform target;

    public float smoothTime = 0.3f;
    public Vector3 offSet;
    private Vector3 velocity = Vector3.zero;

    //private void Start()
    //{
    //    GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
    //    for (int i = 0; i < players.Length; i++)
    //    {
    //        if (players[i].GetComponent<PhotonView>().IsMine)
    //        {
    //            player = players[i];
    //        }
    //        break;
    //    }
    //    GetCamera();
    //}
    //public void GetCamera()
    //{
    //    target = player.transform;
    //}

    void Update()
    {

        if(target != null)
        {
            Vector3 targetPosition = target.position + offSet;
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
