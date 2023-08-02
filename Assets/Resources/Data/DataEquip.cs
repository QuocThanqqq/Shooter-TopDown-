using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]

public class Data
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


[CreateAssetMenu(fileName = "DataEquip", menuName ="DataEquip")]
public class DataEquip : ScriptableObject
{
    public List<Data> datas = new List<Data>();
}
