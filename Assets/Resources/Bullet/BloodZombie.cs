using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodZombie : MonoBehaviour
{
    private void OnSpawned()
    {

        StartCoroutine(WaitHit());
    }

    IEnumerator WaitHit()
    {
        yield return new WaitForSeconds(0.5f);
        BYPoolManager.poolInstance.DeSpawn("hitEnemy", transform);
        BYPoolManager.poolInstance.DeSpawn("hitEnemy2", transform);
    }
}
