using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DataEnemy", menuName = "DataEnemy")]
public class DataEnemy : ScriptableObject
{
    public List<DataEnemys> Enemys = new List<DataEnemys>();
}
