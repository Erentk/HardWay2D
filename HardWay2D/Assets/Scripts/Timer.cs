using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // Oyunun süresi (saniye cinsinden)
    public TextMeshProUGUI timerText; // TextMeshProUGUI türünde
    private float timeRemaining;
    private bool gameIsOver = false; // Oyunun bitip bitmediðini kontrol eder

    // Renkler
    public Color colorGreen = Color.green;
    public Color colorOrange = new Color(1f, 0.65f, 0f);
    public Color colorRed = Color.red;

    void Start()
    {
        timeRemaining = timeLimit;
        DisplayTime(timeRemaining); // Baþlangýçta süreyi UI'da göster
    }

    void Update()
    {
        if (!gameIsOver)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                UpdateColor(timeRemaining); // Renk güncelle
            }
            else
            {
                timeRemaining = 0;
                EndGame(); // Süre dolduðunda oyunu bitir
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Saniyeleri hesapla
        timerText.text = string.Format("{0:00}", seconds); // Sadece saniyeleri göster
    }

    void UpdateColor(float timeToDisplay)
    {
        if (timeToDisplay > 30)
        {
            timerText.color = colorGreen; // Ýlk 30 saniye yeþil
        }
        else if (timeToDisplay > 15)
        {
            timerText.color = colorOrange; // 30 saniye sonrasý turuncu
        }
        else
        {
            timerText.color = colorRed; // 15 saniye sonrasý kýrmýzý
        }
    }

    void EndGame()
    {
        gameIsOver = true; // Oyunu bitir
        timerText.text = "00"; // Timer textini 00 olarak ayarla
        // Oyunun bitiþ iþlemlerini buraya ekleyebilirsiniz
        Debug.Log("Oyun Bitti!");
        // Buraya oyunun bitiþi ile ilgili diðer kodlarý ekleyin
    }
}

