using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;
using UnityEngine.UI;

public class GuageBar : MonoBehaviour
{
    public Slider slider;
    public static float slidervalue = 0;
    public static bool reset = false;
    private void Update()
    {
        this.slider.value += slidervalue;
        slidervalue = 0;

        if(reset)
        {
            this.slider.value = 0;
            reset = false;
        }
    }
}
