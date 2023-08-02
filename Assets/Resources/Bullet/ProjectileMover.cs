using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileMover : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody rb;
    public string mName;
    public string nameHit;
    public float mDames;
    public Weapon weaponDame;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    public void Init(Weapon dataBullet)
    {
        this.weaponDame = dataBullet;
        mDames = weaponDame.weaponRecord.Damage;
  
    }

    public void FixedUpdate()
    {

        if (speed != 0)
        {
            rb.AddForce(transform.forward * 0.1f, ForceMode.Impulse);
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
    private void OnSpawned()
    {
        StopCoroutine(DespawnedDelay());
        StartCoroutine(DespawnedDelay());
    }
    private void OnDeSpawned()
    {
        rb.velocity = Vector3.zero;
    }

    
    public void OnCollisionEnter(Collision collision)
    {
     
        if (collision.gameObject.layer == 0)
        {
           
                BYPoolManager.poolInstance.DeSpawn(mName, transform);
                Transform pool = BYPoolManager.poolInstance.Spawn(nameHit);
                pool.position = transform.position;
                pool.gameObject.GetComponent<HitController>().nameHits = nameHit;
     


        }
        if (collision.gameObject.layer == 7)
        {
            
                collision.gameObject.GetComponent<EnemyBehaviour>().TakeDame(mDames);
                Debug.Log(mDames);
                BYPoolManager.poolInstance.DeSpawn(mName, transform);
                BYPoolManager.poolInstance.Spawn("hitEnemy").position = transform.position;
                BYPoolManager.poolInstance.Spawn("hitEnemy2").position = transform.position;
                Debug.Log("dame");
           
            
        }
    }

    IEnumerator DespawnedDelay()
    {
        yield return new WaitForSeconds(1f);
        BYPoolManager.poolInstance.DeSpawn(mName, transform);

    }

}