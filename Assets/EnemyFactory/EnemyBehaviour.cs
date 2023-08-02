using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class DataEnemys
{
    public string Name;
    public float health;
    public float dame;



}

public class EnemyBehaviour : MonoBehaviour
{

    public DataEnemys data;
    public Animator animator;
    [SerializeField]
    public float currentHealth;
    public GameObject itemPrefab;


    public Transform itemTransform;

    public void DataEnemy(DataEnemys enemyData)
    {
        data = enemyData;
        currentHealth = data.health;

    }
    public void TakeDame(float dameAmount)
    {
        currentHealth -= dameAmount;
        if (currentHealth <= 0)
        {
            animator.Play("Z_DieBack");
            GetComponent<Collider>().enabled = false;
            DropItem();
            StartCoroutine(WaitDie());
            
        }
        else
        {
           
            animator.SetTrigger("getHit");
        }
    }

    // Thay thế bằng prefab của vật phẩm
    public void DropItem()
    {
        Instantiate(itemPrefab,itemTransform.transform.position, Quaternion.identity);
        
    }

    IEnumerator WaitDie()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

