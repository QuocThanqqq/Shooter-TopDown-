using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotationModel : MonoBehaviour
{

    public Vector3 vector3;
   
    void Start()
    {
        transform.DORotate(vector3, 5f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Incremental).SetRelative().SetEase(Ease.Linear);

    
    }

   
}
