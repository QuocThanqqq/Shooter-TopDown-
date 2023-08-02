using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject uiObject;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            uiObject.SetActive(!uiObject.activeSelf);
        }
    }
}
