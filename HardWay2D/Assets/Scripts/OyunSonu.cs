using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class OyunSonu : MonoBehaviour
{
    public TextMeshProUGUI oyunsonuText; // Kaybetme mesaj� i�in TextMeshPro UI
    public TextMeshProUGUI winText; // Kazanma mesaj� i�in TextMeshPro UI
    public Button restartButton; // Yeniden ba�latma butonu
    public Button mainMenuButton; // Ana Men� butonu
    public Health playerHealth; // Sa�l�k scriptine referans
    public BackgroundMusic backgroundMusic;

    private bool isGameOver = false;
    private bool hasWon = false; // Kazanma durumu

    public bool IsGameOver { get { return isGameOver; } } // Oyun biti� durumu

    void Start()
    {
        oyunsonuText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false); // Ana Men� butonunu ba�lang��ta gizle
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu); // Ana Men� butonuna t�klama olay�n� ekle
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Oyunun s�resini ve can� kontrol et
            float gameDuration = playerHealth.GetGameDuration();
            float timeElapsed = Time.timeSinceLevelLoad; // Oyunun ba�lad��� andan itibaren ge�en s�re

            if (playerHealth.GetCurrentHealth() <= 0)
            {
                EndGame(false); // Can bitti, kaybedildi
            }
            else if (timeElapsed >= gameDuration) // S�re dolduysa ve can bitmemi�se kazan�ld�
            {
                EndGame(true); // S�re doldu ve can bitmemi�se kazan�ld�
            }
        }
    }

    public void EndGame(bool won)
    {
        if (isGameOver) return; // Oyun zaten bitmi�se i�lem yapma

        isGameOver = true;
        hasWon = won;

        // Kazanma ve kaybetme mesaj�n� g�ster
        oyunsonuText.gameObject.SetActive(!won); // Kaybetme mesaj�n� g�ster
        winText.gameObject.SetActive(won); // Kazanma mesaj�n� g�ster
        restartButton.gameObject.SetActive(true); // Restart butonunu g�ster
        mainMenuButton.gameObject.SetActive(true); // Ana Men� butonunu g�ster

        Time.timeScale = 0; // Oyunu durdur

        // Oyun biti�i ile ilgili di�er i�lemler...

        // Arka plan m�zi�ini durdur
        if (backgroundMusic != null)
        {
            backgroundMusic.StopMusic();
        }
    }

    void RestartGame()
    {
        // Oyunu yeniden ba�latmadan �nce, Time.timeScale'� s�f�rdan normal hale getiriyoruz
        Time.timeScale = 1; // Oyun h�z�n� normal yap
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Ayn� sahneyi yeniden y�kle
    }

    void ReturnToMainMenu()
    {
        // Time.timeScale'� s�f�rdan normal hale getiriyoruz
        Time.timeScale = 1; // Oyun h�z�n� normal yap
        SceneManager.LoadScene("MenuScene"); // Ana men� sahnesini y�kle
    }
}

















