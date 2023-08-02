using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    public Transform anchor;
    public WeaponBehaviour[] gun;
    public WeaponBehaviour currentWeapon;



    /// shoot
    public Transform firePoint;
    public Camera Cam;
    public Animation Anim;
    private Ray RayMouse;
    private Quaternion rotation;

    Dictionary<string, WeaponBehaviour> Dic_Gun = new Dictionary<string, WeaponBehaviour>();


    public AudioSource audioHandgun;


    public void Start()
    {

        for (int i = 0; i < gun.Length; i++)
        {
            WeaponBehaviour _gun = Instantiate(gun[i]);
            WeaponRecord data = DataManager.instance.GunData.weapons.Find(x => x.Name == gun[i].name);
            _gun.transform.SetParent(anchor, false);
            Dic_Gun[data.Name] = _gun;
            WeaponBehaviour weapon = _gun.GetComponent<WeaponBehaviour>();
            weapon.Init(this, new Weapon { weaponRecord = data });
            _gun.gameObject.SetActive(false);

        }


        SwitchWeapon("M4A1_1");

        audioHandgun = GetComponent<AudioSource>();

       

    }

    public void Update()
    {
       
        if (!PauseController.isPaused)
        {
            Swith();
            Shoot();
        }
    }

    /// SHOOT
    public void Shoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            currentWeapon.firePoint = firePoint;
            currentWeapon.Attack();
        }

        if (Cam != null)
        {
            RaycastHit hit;
            var mousePos = Input.mousePosition;
            RayMouse = Cam.ScreenPointToRay(mousePos);
            if (Physics.Raycast(RayMouse.origin, RayMouse.direction, out hit))
            {
                RotateToMouseDirection(hit.point);
            }
        }
        void RotateToMouseDirection(Vector3 destination)
        {
            destination = new Vector3(0, transform.eulerAngles.y, 0);
            rotation = Quaternion.Euler(destination);
            transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, 1f);
        }
    }



    /// SWITCH WEAPON
    public void SwitchWeapon(string name)
    {
        WeaponBehaviour newWeapon = Dic_Gun[name];
        if (currentWeapon != null)
        {
            currentWeapon.gameObject.SetActive(false);
        }
        currentWeapon = newWeapon;
        currentWeapon.GetWeapon();
        currentWeapon.gameObject.SetActive(true);
    }




  
    /// SWITH WITH KEY:1,2,3
   
    public void Swith()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchWeapon("M4A1_1");
 
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchWeapon("Handgun_1");
       
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SwitchWeapon("Knife_1");
          
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SwitchWeapon("Rocket_1");
           
        }
    }

   
}


public enum WeaponType
{
    Handgun,
    M4A1,
    Knife,
    Rocket

}

