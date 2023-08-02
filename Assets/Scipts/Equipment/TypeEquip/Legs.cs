using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : EquiqBehaviour
{

    public override void InitData()
    {
        base.InitData();
        TypeEquip = TypeEquip.Legs;
        mIEquip = new ILegs();
        mIEquip.Init(this);
    }

}

public class ILegs : IEquip
{
    public Legs legsEquip;

    public void Init(EquiqBehaviour _equiqBehaviour)
    {
        legsEquip = (Legs)_equiqBehaviour;
    }

    public void Defend(float armor)
    {
        ///
    }
}
