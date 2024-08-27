using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourglassColorChange : MonoBehaviour
{
    public Image hourglassImage;  // Kum saati görseli
    public float timeLimit = 60f; // Toplam süre
    private float timeRemaining;

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateHourglassColor(timeRemaining);  // Baþlangýçta renk güncelle
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateHourglassColor(timeRemaining);  // Her karede renk güncelle
        }
        else
        {
            timeRemaining = 0;
            UpdateHourglassColor(timeRemaining);  // Süre dolduðunda da renk güncelle
        }
    }

    void UpdateHourglassColor(float timeLeft)
    {
        if (timeLeft > 30f)
        {
            hourglassImage.color = Color.green;  // 30 saniyeden fazla kaldýysa yeþil
        }
        else if (timeLeft > 15f)
        {
            hourglassImage.color = Color.yellow;  // 15-30 saniye arasý kaldýysa turuncu
        }
        else
        {
            hourglassImage.color = Color.red;  // 15 saniyeden az kaldýysa kýrmýzý
        }
    }
}
