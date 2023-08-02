using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class DataUIS
{
    [SerializeField]
    private string id;
    public string ID
    {
        get
        {
            return id;
        }
    }

    [SerializeField]
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
    }
}


[CreateAssetMenu(fileName = "DataUI", menuName = "DataUI")]

public class DataUI : ScriptableObject
{
    public List<DataUIS> dataGUI = new List<DataUIS>();
}
