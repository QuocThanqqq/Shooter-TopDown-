using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : EquiqBehaviour
{
    public override void InitData()
    {
        base.InitData();
        TypeEquip = TypeEquip.Body;
        mIEquip = new IBody();
        mIEquip.Init(this);
    }

}

public class IBody : IEquip
{
    public Body bodyEquip;

    public void Init(EquiqBehaviour _equiqBehaviour)
    {
        bodyEquip = (Body)_equiqBehaviour;
    }

    public void Defend(float armor)
    {
        ///
    }
}
