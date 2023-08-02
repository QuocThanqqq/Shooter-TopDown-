using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public DataEnemy dataEnemy;

    public void Start()
    {    
        for (int i = 0; i < dataEnemy.Enemys.Count; i++)
        {
           
            GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            EnemyBehaviour enemyBehaviour = enemy.GetComponent<EnemyBehaviour>();
            enemyBehaviour.DataEnemy(dataEnemy.Enemys[i]);

        }
    }
}

