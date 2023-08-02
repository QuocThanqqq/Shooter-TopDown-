using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataAPIController : BYSingleton<DataAPIController>
{

    public LocalDataModel dataModel;


    public void InitData(Action callBack)
    {
        dataModel.CreateData(callBack);

    }
    public PlayerInfo GetInfo()
    {
        return dataModel.Read<PlayerInfo>(DataPath.INFO);
    }

    public string GetSlotItem(string path)
    {
        return dataModel.Read<string>(path);
    }

    public void UpdateSlotItem(string path, string dataNew, Action callBack)
    {
        dataModel.UpdateData(path, dataNew, callBack);

    }
}
