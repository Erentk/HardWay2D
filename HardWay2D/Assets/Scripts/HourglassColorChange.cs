using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HourglassColorChange : MonoBehaviour
{
    public Image hourglassImage;  // Kum saati g�rseli
    public float timeLimit = 60f; // Toplam s�re
    private float timeRemaining;

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateHourglassColor(timeRemaining);  // Ba�lang��ta renk g�ncelle
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateHourglassColor(timeRemaining);  // Her karede renk g�ncelle
        }
        else
        {
            timeRemaining = 0;
            UpdateHourglassColor(timeRemaining);  // S�re doldu�unda da renk g�ncelle
        }
    }

    void UpdateHourglassColor(float timeLeft)
    {
        if (timeLeft > 30f)
        {
            hourglassImage.color = Color.green;  // 30 saniyeden fazla kald�ysa ye�il
        }
        else if (timeLeft > 15f)
        {
            hourglassImage.color = Color.yellow;  // 15-30 saniye aras� kald�ysa turuncu
        }
        else
        {
            hourglassImage.color = Color.red;  // 15 saniyeden az kald�ysa k�rm�z�
        }
    }
}
