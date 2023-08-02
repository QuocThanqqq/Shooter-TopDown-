using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Handgun : WeaponBehaviour
{
    public override void InitData()
    {
        base.InitData();
        weaponType = WeaponType.Handgun;
        typeDamage = new IHandgun();
        typeDamage.Init(this);

        /// Bullet
        BYPool bullet = new BYPool();
        bullet.prefab_ = bulletPrefab;
        bullet.namePool = "Handgun";
        bullet.total = 10;
        BYPoolManager.poolInstance.AddNewPool(bullet);

        /// Hit
        BYPool hit = new BYPool();
        hit.prefab_ = hitsPrefab;
        hit.namePool = "Hit1";
        hit.total = 10;
        BYPoolManager.poolInstance.AddNewPool(hit);
        

    }

}

public class IHandgun: IWeapon
{
    public Handgun handgun;
    public void Init(WeaponBehaviour weaponBehaviour)
    {
        handgun = (Handgun)weaponBehaviour;
    }

    public void Attack(float Damage, Action callBack)
    {

        handgun.weaponController.audioHandgun.Play();
        Transform bullet = BYPoolManager.poolInstance.Spawn("Handgun");
        bullet.gameObject.GetComponent<ProjectileMover>();
        bullet.position = handgun.firePoint.position;
        bullet.rotation = handgun.firePoint.rotation;
        bullet.GetComponent<ProjectileMover>().mName = "Handgun";
        bullet.GetComponent<ProjectileMover>().nameHit = "Hit1";
        bullet.GetComponent<ProjectileMover>().Init(handgun.data);
        callBack?.Invoke();
    }
}
