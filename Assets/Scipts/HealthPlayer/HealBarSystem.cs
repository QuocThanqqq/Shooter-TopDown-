using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBarSystem : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
     
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
