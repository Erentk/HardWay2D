using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColoChange : MonoBehaviour
{
    public Slider healthSlider;  // Slider referans�
    public Image fillImage;      // Fill image referans�

    void Start()
    {
        UpdateSliderColor(healthSlider.value);  // Ba�lang��ta renk g�ncelle
    }

    void Update()
    {
        UpdateSliderColor(healthSlider.value);  // Her karede renk g�ncelle
    }

    void UpdateSliderColor(float value)
    {
        if (value >= 70)
        {
            fillImage.color = Color.green;  // Sa�l�k y�ksekse ye�il
        }
        else if (value >= 30)
        {
            fillImage.color = new Color(1f, 0.65f, 0f);  // Sa�l�k orta seviyedeyse turuncu
        }
        else
        {
            fillImage.color = Color.red;  // Sa�l�k d���kse k�rm�z�
        }
    }
}

