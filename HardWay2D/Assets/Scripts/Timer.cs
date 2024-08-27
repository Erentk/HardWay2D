using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f; // Oyunun s�resi (saniye cinsinden)
    public TextMeshProUGUI timerText; // TextMeshProUGUI t�r�nde
    private float timeRemaining;
    private bool gameIsOver = false; // Oyunun bitip bitmedi�ini kontrol eder

    // Renkler
    public Color colorGreen = Color.green;
    public Color colorOrange = new Color(1f, 0.65f, 0f);
    public Color colorRed = Color.red;

    void Start()
    {
        timeRemaining = timeLimit;
        DisplayTime(timeRemaining); // Ba�lang��ta s�reyi UI'da g�ster
    }

    void Update()
    {
        if (!gameIsOver)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                UpdateColor(timeRemaining); // Renk g�ncelle
            }
            else
            {
                timeRemaining = 0;
                EndGame(); // S�re doldu�unda oyunu bitir
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        float seconds = Mathf.FloorToInt(timeToDisplay % 60); // Saniyeleri hesapla
        timerText.text = string.Format("{0:00}", seconds); // Sadece saniyeleri g�ster
    }

    void UpdateColor(float timeToDisplay)
    {
        if (timeToDisplay > 30)
        {
            timerText.color = colorGreen; // �lk 30 saniye ye�il
        }
        else if (timeToDisplay > 15)
        {
            timerText.color = colorOrange; // 30 saniye sonras� turuncu
        }
        else
        {
            timerText.color = colorRed; // 15 saniye sonras� k�rm�z�
        }
    }

    void EndGame()
    {
        gameIsOver = true; // Oyunu bitir
        timerText.text = "00"; // Timer textini 00 olarak ayarla
        // Oyunun biti� i�lemlerini buraya ekleyebilirsiniz
        Debug.Log("Oyun Bitti!");
        // Buraya oyunun biti�i ile ilgili di�er kodlar� ekleyin
    }
}

