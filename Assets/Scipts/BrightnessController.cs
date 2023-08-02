using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
public class BrightnessController : MonoBehaviour
{
    public Slider sliderLight;
    public PostProcessProfile processProfile;
    public PostProcessLayer layer;

    AutoExposure autoExposure;
    // Start is called before the first frame update
    void Start()
    {
        processProfile.TryGetSettings(out autoExposure);
        if (PlayerPrefs.HasKey("light"))
        {
            LoadBrightness();
        }
        else
        {
            SetBrightness();
        }
            
        
    }

   public void  SetBrightness()
    {
        float value = sliderLight.value;
        if (value !=0)
        {
            autoExposure.keyValue.value = value;
            PlayerPrefs.SetFloat("light", value);
        }
        else
        {
            autoExposure.keyValue.value = .05f;
        }
    }

    public void LoadBrightness()
    {
        sliderLight.value = PlayerPrefs.GetFloat("light");
        SetBrightness();
    }
}
