using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Maksimum can de�eri
    public int currentHealth;  // Mevcut can de�eri

    public Slider healthSlider; // Can� g�sterecek UI Slider
    public TextMeshProUGUI timeText; // S�reyi g�sterecek UI Text
    public OyunSonu gameOverManager; // Oyun Sonu scriptine referans

    public float gameDuration = 60f; // Oyun s�resi
    private float timeRemaining; // Kalan s�re

    void Start()
    {
        currentHealth = maxHealth; // Ba�lang��ta can maksimum olacak
        healthSlider.maxValue = maxHealth; // Slider'�n maksimum de�eri ayarlan�yor
        UpdateHealthUI(); // Can de�erini UI'da g�ster

        timeRemaining = gameDuration; // Ba�lang��ta kalan s�re maksimum olacak
        UpdateTimeUI(); // S�reyi UI'da g�ster
    }

    void Update()
    {
        if (!gameOverManager.IsGameOver)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                gameOverManager.EndGame(currentHealth > 0); // S�re bitti, kazanma veya kaybetme durumu
            }
            UpdateTimeUI(); // S�reyi UI'da g�ncelle
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Engellere �arpt���nda
        {
            TakeDamage(10); // �arpmada 10 birim can azal�r
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI(); // Can de�erini UI'da g�ncelle

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver(); // Can s�f�r olursa oyun biter
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth; // Slider'�n de�erini g�ncelle
        UpdateSliderColor(); // Slider rengini g�ncelle
    }

    void UpdateTimeUI()
    {
        UpdateTimeTextColor(); // S�re metninin rengini g�ncelle
    }

    void UpdateSliderColor()
    {
        // Sa�l�k slider rengini g�ncelle
        float healthPercent = (float)currentHealth / maxHealth;
        healthSlider.fillRect.GetComponent<Image>().color = Color.Lerp(Color.red, Color.green, healthPercent);
    }

    void GameOver()
    {
        if (gameOverManager != null)
        {
            gameOverManager.EndGame(false); // Oyun kaybedildi
        }
    }

    void UpdateTimeTextColor()
    {
        // S�reye ba�l� olarak renk de�i�imini yap
        float timePercent = timeRemaining / gameDuration;
        if (timePercent > 0.5f)
        {
            timeText.color = Color.green; // S�re %50'den fazla ise ye�il
        }
        else if (timePercent > 0.25f)
        {
            timeText.color = Color.yellow; // S�re %25 ile %50 aras�nda ise sar�
        }
        else
        {
            timeText.color = Color.red; // S�re %25'ten az ise k�rm�z�
        }
    }

    public float GetGameDuration()
    {
        return gameDuration;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}













