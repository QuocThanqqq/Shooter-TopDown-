using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Knife : WeaponBehaviour
{ 
    public override void InitData()
    {
        base.InitData();
        weaponType = WeaponType.Knife;
        typeDamage = new IKnife();
        typeDamage.Init(this);
    }

}

public class IKnife : IWeapon
{
    public Knife knife;

    public void Init(WeaponBehaviour weaponBehaviour)
    {
        knife = (Knife)weaponBehaviour;
        
    }

    public void Attack(float Damage, Action callBack)
    {
      
        callBack?.Invoke();
    }
}
