using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extra : EquiqBehaviour
{

    public override void InitData()
    {
        base.InitData();
        TypeEquip = TypeEquip.Extra;
        mIEquip = new IExtra();
        mIEquip.Init(this);
    }

}

public class IExtra : IEquip
{
    public Extra extraEquip;

    public void Init(EquiqBehaviour _equiqBehaviour)
    {
        extraEquip = (Extra)_equiqBehaviour;
    }

    public void Defend(float armor)
    {
        ///
    }
}
