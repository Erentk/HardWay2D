using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100; // Maksimum can deðeri
    public int currentHealth;  // Mevcut can deðeri

    public Slider healthSlider; // Caný gösterecek UI Slider
    public TextMeshProUGUI timeText; // Süreyi gösterecek UI Text
    public OyunSonu gameOverManager; // Oyun Sonu scriptine referans

    public float gameDuration = 60f; // Oyun süresi
    private float timeRemaining; // Kalan süre

    void Start()
    {
        currentHealth = maxHealth; // Baþlangýçta can maksimum olacak
        healthSlider.maxValue = maxHealth; // Slider'ýn maksimum deðeri ayarlanýyor
        UpdateHealthUI(); // Can deðerini UI'da göster

        timeRemaining = gameDuration; // Baþlangýçta kalan süre maksimum olacak
        UpdateTimeUI(); // Süreyi UI'da göster
    }

    void Update()
    {
        if (!gameOverManager.IsGameOver)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                gameOverManager.EndGame(currentHealth > 0); // Süre bitti, kazanma veya kaybetme durumu
            }
            UpdateTimeUI(); // Süreyi UI'da güncelle
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Engellere çarptýðýnda
        {
            TakeDamage(10); // Çarpmada 10 birim can azalýr
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        UpdateHealthUI(); // Can deðerini UI'da güncelle

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameOver(); // Can sýfýr olursa oyun biter
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = currentHealth; // Slider'ýn deðerini güncelle
        UpdateSliderColor(); // Slider rengini güncelle
    }

    void UpdateTimeUI()
    {
        UpdateTimeTextColor(); // Süre metninin rengini güncelle
    }

    void UpdateSliderColor()
    {
        // Saðlýk slider rengini güncelle
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
        // Süreye baðlý olarak renk deðiþimini yap
        float timePercent = timeRemaining / gameDuration;
        if (timePercent > 0.5f)
        {
            timeText.color = Color.green; // Süre %50'den fazla ise yeþil
        }
        else if (timePercent > 0.25f)
        {
            timeText.color = Color.yellow; // Süre %25 ile %50 arasýnda ise sarý
        }
        else
        {
            timeText.color = Color.red; // Süre %25'ten az ise kýrmýzý
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













