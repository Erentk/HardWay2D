using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class OyunSonu : MonoBehaviour
{
    public TextMeshProUGUI oyunsonuText; // Kaybetme mesajý için TextMeshPro UI
    public TextMeshProUGUI winText; // Kazanma mesajý için TextMeshPro UI
    public Button restartButton; // Yeniden baþlatma butonu
    public Button mainMenuButton; // Ana Menü butonu
    public Health playerHealth; // Saðlýk scriptine referans
    public BackgroundMusic backgroundMusic;

    private bool isGameOver = false;
    private bool hasWon = false; // Kazanma durumu

    public bool IsGameOver { get { return isGameOver; } } // Oyun bitiþ durumu

    void Start()
    {
        oyunsonuText.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false); // Ana Menü butonunu baþlangýçta gizle
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu); // Ana Menü butonuna týklama olayýný ekle
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Oyunun süresini ve caný kontrol et
            float gameDuration = playerHealth.GetGameDuration();
            float timeElapsed = Time.timeSinceLevelLoad; // Oyunun baþladýðý andan itibaren geçen süre

            if (playerHealth.GetCurrentHealth() <= 0)
            {
                EndGame(false); // Can bitti, kaybedildi
            }
            else if (timeElapsed >= gameDuration) // Süre dolduysa ve can bitmemiþse kazanýldý
            {
                EndGame(true); // Süre doldu ve can bitmemiþse kazanýldý
            }
        }
    }

    public void EndGame(bool won)
    {
        if (isGameOver) return; // Oyun zaten bitmiþse iþlem yapma

        isGameOver = true;
        hasWon = won;

        // Kazanma ve kaybetme mesajýný göster
        oyunsonuText.gameObject.SetActive(!won); // Kaybetme mesajýný göster
        winText.gameObject.SetActive(won); // Kazanma mesajýný göster
        restartButton.gameObject.SetActive(true); // Restart butonunu göster
        mainMenuButton.gameObject.SetActive(true); // Ana Menü butonunu göster

        Time.timeScale = 0; // Oyunu durdur

        // Oyun bitiþi ile ilgili diðer iþlemler...

        // Arka plan müziðini durdur
        if (backgroundMusic != null)
        {
            backgroundMusic.StopMusic();
        }
    }

    void RestartGame()
    {
        // Oyunu yeniden baþlatmadan önce, Time.timeScale'ý sýfýrdan normal hale getiriyoruz
        Time.timeScale = 1; // Oyun hýzýný normal yap
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Ayný sahneyi yeniden yükle
    }

    void ReturnToMainMenu()
    {
        // Time.timeScale'ý sýfýrdan normal hale getiriyoruz
        Time.timeScale = 1; // Oyun hýzýný normal yap
        SceneManager.LoadScene("MenuScene"); // Ana menü sahnesini yükle
    }
}

















