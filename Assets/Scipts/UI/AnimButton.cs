using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AnimButton : MonoBehaviour
{

    public RectTransform menuControl, multiplayerControl;
    
    
    void Start()
    {
        menuControl.DOAnchorPos(Vector2.zero, 0.75f);
        
    }
    public void MultiplayButton()
    {
        menuControl.DOAnchorPos(new Vector2(-1000, 0), 0.75f);
        multiplayerControl.DOAnchorPos(new Vector2(0, 0), 0.75f);
    }

    public  void CloseMultiplayButton()
    {
        menuControl.DOAnchorPos(new Vector2(0, 0), 1f);
        multiplayerControl.DOAnchorPos(new Vector2(-1000, 0), 0.75f);
    }

}
