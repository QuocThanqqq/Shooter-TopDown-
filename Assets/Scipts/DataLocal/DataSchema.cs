using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataSchema
{
}
[Serializable]
public class UserData
{
    [SerializeField]
    public PlayerInfo info;
}
[Serializable]
public class PlayerInfo
{
    public string body_slot_1;
    public string head_slot_1;
    public string extra_slot_1;
    public string legs_slot_1;
}