using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Newtonsoft.Json;
using UnityEngine;

public class LocalDataModel : MonoBehaviour
{
    private UserData userData;

    public void CreateData(Action callBack)
    {
        userData = LoadData();
        if (userData != null)
        {
            callBack?.Invoke();
        }
        else
        {

            userData = new UserData();
            PlayerInfo info = new PlayerInfo();
            info.head_slot_1 = "Head_B1";
            info.body_slot_1 = "Body_A";
            info.extra_slot_1 = "Extra_A";
            info.legs_slot_1 = "Legs_A";
            userData.info = info;
            SaveData();
            callBack?.Invoke();
        }
    }
    private UserData LoadData()
    {

        if (PlayerPrefs.HasKey("DATA"))
        {
            string dataJson = PlayerPrefs.GetString("DATA");
            return JsonConvert.DeserializeObject<UserData>(dataJson);
        }
        else
        {
            return null;
        }
    }
    private void SaveData()
    {
        string dataJson = JsonConvert.SerializeObject(userData);
        PlayerPrefs.SetString("DATA", dataJson);
    }


    private List<string> GetPath(string path)
    {
        string[] s = path.Split('/');
        List<string> ls = new List<string>();
        ls.AddRange(s);
        return ls;
    }

    public T Read<T>(string path)
    {
        object data = null;
        ReadDataByPath(GetPath(path), userData, out data);
        return (T)data;
    }

    private void ReadDataByPath(List<string> paths, object data, out object dataOut)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
        if (paths.Count == 1)
        {
            dataOut = field.GetValue(data);
        }
        else
        {
            paths.RemoveAt(0);
            ReadDataByPath(paths, field.GetValue(data), out dataOut);
        }
    }

    public void UpdateData(string path, object dataNew, Action callback)
    {
        List<object> ls_datachange = new List<object>();
        List<string> paths = GetPath(path);
        UpdateDataByPath(paths, userData, dataNew, ref ls_datachange, callback);
        SaveData();
        string e_path = string.Empty;
        paths.Clear();
        paths = GetPath(path);
        //for (int i = 0; i < paths.Count; i++)
        //{
        //    if (i == 0)
        //    {
        //        e_path = paths[0];
        //    }
        //    else
        //    {
        //        e_path = e_path + "/" + paths[i];
        //    }
        //   // ls_datachange[i].TriggerEventData(e_path);
        //}
    }

    private void UpdateDataByPath(List<string> paths, object data, object datanew, ref List<object> datas_change, Action callback = null)
    {
        string p = paths[0];
        Type t = data.GetType();
        FieldInfo field = t.GetField(p);
        if (paths.Count == 1)
        {
            //datas_change.Add(datanew);
            field.SetValue(data, datanew);
            callback?.Invoke();
        }
        else
        {
            object dataAdd = field.GetValue(data);
           // datas_change.Add(dataAdd);
            paths.RemoveAt(0);
            UpdateDataByPath(paths, dataAdd, datanew, ref datas_change, callback);
        }
    }
}
