using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquiqBehaviour : MonoBehaviour
{
    public EquipController equipController;
    public IEquip mIEquip;
    public TypeEquip TypeEquip;
    public Data mdata;
    public PlayerEquipController playerEquipController;

    public void Init(EquipController equipController = null)
    {
        this.equipController = equipController;
        InitData();
    }

    public virtual void InitData()
    {

    }

    public void Defend()
    {

    }
    public virtual void GetBody(string _getEquip)
    {

    }

    public void myData(Data _data)
    {
        mdata = _data;
    }
}
