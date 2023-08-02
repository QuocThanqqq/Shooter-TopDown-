using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioButton : MonoBehaviour
{
    public AudioSource mAudioSource;
    public AudioClip mHover;
    public AudioClip mClick;



    public void HoverButton()
    {
        mAudioSource.PlayOneShot(mHover);
    }

    public void ClickButton()
    {
        mAudioSource.PlayOneShot(mClick);
    }
}
