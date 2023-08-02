using System;
using UnityEngine;

public class Rocket : WeaponBehaviour
{
    public override void InitData()
    {
        base.InitData();
        weaponType = WeaponType.Rocket;
        typeDamage = new IRocket();
        typeDamage.Init(this);

        /// Bullet
        BYPool bullet = new BYPool();
        bullet.prefab_ = bulletPrefab;
        bullet.namePool = "Rocket";
        bullet.total = 10;
        BYPoolManager.poolInstance.AddNewPool(bullet);

        /// Hit
        BYPool hit = new BYPool();
        hit.prefab_ = hitsPrefab;
        hit.namePool = "Hit3";
        hit.total = 10;
        BYPoolManager.poolInstance.AddNewPool(hit);

    }

}

public class IRocket : IWeapon
{
    public Rocket rocket;
    public void Init(WeaponBehaviour weaponBehaviour)
    {
        rocket = (Rocket)weaponBehaviour;
    }

    public void Attack(float Damage, Action callBack)
    {
        rocket.weaponController.audioHandgun.Play();
        Transform bullet = BYPoolManager.poolInstance.Spawn("Rocket");
        bullet.gameObject.GetComponent<ProjectileMover>();
        bullet.position = rocket.firePoint.position;
        bullet.rotation = rocket.firePoint.rotation;
        bullet.GetComponent<ProjectileMover>().mName = "Rocket";
        bullet.GetComponent<ProjectileMover>().nameHit = "Hit3";
        bullet.GetComponent<ProjectileMover>().Init(rocket.data);
        callBack?.Invoke();
    }
}

