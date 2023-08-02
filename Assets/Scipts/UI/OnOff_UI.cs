using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOff_UI : MonoBehaviour
{
    public GameObject ui;
    public void ClickOn()
    {
        if(ui.activeInHierarchy == false)
        {
            ui.SetActive(true);
        }
        else
        {
            ui.SetActive(false);
        }
    } 
    
}
