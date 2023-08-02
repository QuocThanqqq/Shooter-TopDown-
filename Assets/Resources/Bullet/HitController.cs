using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitController : MonoBehaviour
{
    public string nameHits;
    private void OnSpawned()
    {

        StartCoroutine(WaitHit());
    }

    IEnumerator WaitHit()
    {
        yield return new WaitForSeconds(0.5f);
        BYPoolManager.poolInstance.DeSpawn(nameHits, transform);
    }
}
