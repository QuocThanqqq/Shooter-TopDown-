using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Weapon
{
    public WeaponRecord weaponRecord;
}
public class WeaponBehaviour : MonoBehaviour
{

    public WeaponController weaponController;
    public IWeapon typeDamage;
    public WeaponType weaponType;
    public Weapon data;

    [NonSerialized]
    public Animator animator;
    public AnimatorOverrideController animController;
    public ParticleSystem flashController;

    public Transform firePoint;
    public Transform bulletPrefab;
    public Transform hitsPrefab;
    public string mName;
    public float mDame;


    public void Init(WeaponController _weaponController, Weapon dataNew)
    {

        this.data = dataNew;
        mName = data.weaponRecord.Name;
        mDame = data.weaponRecord.Damage;
        this.weaponController = _weaponController;
        if (animator == null)
            animator = weaponController.gameObject.GetComponent<Animator>();


        InitData();


    }
    public virtual void InitData()
    {

    }

    public void Attack()
    {

        weaponController.Anim.Play();
        animator.Play("Attack", 1);
        flashController.Play();
        typeDamage.Attack(data.weaponRecord.Damage, () =>
        {
            animator.Play("in", 1);
            Debug.Log("RunBack");
        });

    }

    public virtual void GetWeapon()
    {
        GetCurrentAnim();
    }

    public void GetCurrentAnim()
    {
        animator.runtimeAnimatorController = animController;

    }
}
