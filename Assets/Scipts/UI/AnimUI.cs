using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class AnimUI : MonoBehaviour
{

    public RectTransform gun1, gun2, gun3, gun4;
    void Start()
    {
        gun1.DOAnchorPos(new Vector2(-555,-50), 1f);
      

    }
    private void Update()
    {
        if (!PauseController.isPaused)

        {
            SwitchUI();
        }
    }

    public void SwitchUI()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            gun1.DOAnchorPos(new Vector2(-555,-50), 1f);
            gun2.DOAnchorPos(new Vector2(40, -50), 1f);
            gun3.DOAnchorPos(new Vector2(40, -50), 1f);
            gun4.DOAnchorPos(new Vector2(40, -50), 1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            gun1.DOAnchorPos(new Vector2(40, -50), 1f);
            gun2.DOAnchorPos(new Vector2(-555, -50), 1f);
            gun3.DOAnchorPos(new Vector2(40, -50), 1f);
            gun4.DOAnchorPos(new Vector2(40, -50), 1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            gun1.DOAnchorPos(new Vector2(40, -50), 1f);
            gun2.DOAnchorPos(new Vector2(40, -50), 1f);
            gun3.DOAnchorPos(new Vector2(-555, -50), 1f);
            gun4.DOAnchorPos(new Vector2(40, -50), 1f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            gun1.DOAnchorPos(new Vector2(40, -50), 1f);
            gun2.DOAnchorPos(new Vector2(40, -50), 1f);
            gun3.DOAnchorPos(new Vector2(40, -50), 1f);
            gun4.DOAnchorPos(new Vector2(-555, -50), 1f);
        }
    }
}
