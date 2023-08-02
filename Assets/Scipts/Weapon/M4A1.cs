using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class M4A1 : WeaponBehaviour
{
    public override void InitData()
    {
        base.InitData();
        weaponType = WeaponType.M4A1;
        typeDamage = new IM4A1();
        typeDamage.Init(this);

        /// Bullet
        BYPool bullet = new BYPool();
        bullet.prefab_ = bulletPrefab;
        bullet.namePool = "M4A1";
        bullet.total = 10;
        BYPoolManager.poolInstance.AddNewPool(bullet);

        /// Hit
        BYPool hit = new BYPool();
        hit.prefab_ = hitsPrefab;
        hit.namePool = "Hit2";
        hit.total = 10;
        BYPoolManager.poolInstance.AddNewPool(hit);

    }

}

public class IM4A1 : IWeapon
{
    public M4A1 m4a1;
    public void Init(WeaponBehaviour weaponBehaviour)
    {
        m4a1 = (M4A1)weaponBehaviour;
    }

    public void Attack(float Damage, Action callBack)
    {
        m4a1.weaponController.audioHandgun.Play();
        Transform bullet = BYPoolManager.poolInstance.Spawn("M4A1");
        bullet.gameObject.GetComponent<ProjectileMover>();
        bullet.position = m4a1.firePoint.position;
        bullet.rotation = m4a1.firePoint.rotation;
        bullet.GetComponent<ProjectileMover>().mName = "M4A1";
        bullet.GetComponent<ProjectileMover>().nameHit = "Hit2";
        bullet.GetComponent<ProjectileMover>().Init(m4a1.data);
        callBack?.Invoke();
    }
}
