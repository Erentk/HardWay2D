using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderColoChange : MonoBehaviour
{
    public Slider healthSlider;  // Slider referansý
    public Image fillImage;      // Fill image referansý

    void Start()
    {
        UpdateSliderColor(healthSlider.value);  // Baþlangýçta renk güncelle
    }

    void Update()
    {
        UpdateSliderColor(healthSlider.value);  // Her karede renk güncelle
    }

    void UpdateSliderColor(float value)
    {
        if (value >= 70)
        {
            fillImage.color = Color.green;  // Saðlýk yüksekse yeþil
        }
        else if (value >= 30)
        {
            fillImage.color = new Color(1f, 0.65f, 0f);  // Saðlýk orta seviyedeyse turuncu
        }
        else
        {
            fillImage.color = Color.red;  // Saðlýk düþükse kýrmýzý
        }
    }
}

