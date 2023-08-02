using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheatController : MonoBehaviour
{
    public InputField inputCode;
    public GameObject player;
  


    public void SetCheat()
    {
        if(inputCode.text == "adddna")
        {
            player.SendMessage("DnaCheat");
        }


        if (inputCode.text == "addhealth")
        {
            player.SendMessage("HealthCheat");
        }
    }
}
