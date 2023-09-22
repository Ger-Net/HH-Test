using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    
    public void Init(int value)
    {
        _slider.maxValue = value;
        _slider.wholeNumbers = true;
        _slider.value = value;
    }
    public void UpdateSlider(int value)
    {
        _slider.value = value;
    }
}
