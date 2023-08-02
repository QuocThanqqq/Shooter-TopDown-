using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DataAPIController.instance.InitData(() =>
       {

           Debug.Log("Done");


           Debug.Log(DataAPIController.instance.GetSlotItem(DataPath.HEAD_1));
       });



        Debug.Log(DataAPIController.instance.GetSlotItem(DataPath.HEAD_1));
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        DataAPIController.instance.UpdateSlotItem(DataPath.HEAD_1, "Head_B1", () =>
    //        {

    //            Debug.Log("Update Done " + DataAPIController.instance.GetSlotItem(DataPath.HEAD_1));


    //        });
    //    }
    //}
}
