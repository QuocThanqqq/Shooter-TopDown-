using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : EquiqBehaviour
{
    public override void InitData()
    {
        base.InitData();
        TypeEquip = TypeEquip.Head;
        mIEquip = new IHead();
        mIEquip.Init(this);
    }

}

public class IHead : IEquip
{
    public Head headEquip;

    public void Init(EquiqBehaviour _equiqBehaviour)
    {
        headEquip = (Head)_equiqBehaviour;
    }

    public void Defend(float armor)
    {
        ///
    }
}
