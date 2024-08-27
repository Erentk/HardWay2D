using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour
{
    private bool isPaused = false;
    public GameObject pauseUI;  // Pause UI Panel veya Canvas
    public Image pauseImage;    // Pause Image
    public TextMeshProUGUI gamepauseText;  // Pause Text
    public AudioSource backgroundMusic; // Background music source
    public Button mainMenuButton; // Main Menu button
    public Button restartButton; // Restart button

    // Ses butonlarý
    public Button muteButton; // Sesi kapatma butonu
    public Button unmuteButton; // Sesi açma butonu

    void Start()
    {
        // Baþlangýçta pause UI'ý kapalý yap
        SetPauseUIActive(false);

        // MainMenu butonuna týklama olayýný ekle
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }

        // Restart butonuna týklama olayýný ekle
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        // Mute ve Unmute butonlarýna týklama olaylarýný ekle
        if (muteButton != null)
        {
            muteButton.onClick.AddListener(MuteSound);
        }

        if (unmuteButton != null)
        {
            unmuteButton.onClick.AddListener(UnmuteSound);
        }
    }

    void Update()
    {
        // Space tuþuna basýldýðýnda
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isPaused)
            {
                // Oyunu devam ettir
                ResumeGame();
            }
            else
            {
                // Oyunu durdur
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Oyunu durdur
        isPaused = true;
        SetPauseUIActive(true); // Pause UI'ý aç

        // Background müziði durdur
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        isPaused = false;
        SetPauseUIActive(false); // Pause UI'ý kapat

        // Background müziði devam ettir
        if (backgroundMusic != null)
        {
            backgroundMusic.Play();
        }
    }

    void SetPauseUIActive(bool isActive)
    {
        if (pauseImage != null)
        {
            pauseImage.gameObject.SetActive(isActive); // Image'i aktif/pasif yap
        }

        if (gamepauseText != null)
        {
            gamepauseText.gameObject.SetActive(isActive); // Text'i aktif/pasif yap
        }

        if (mainMenuButton != null)
        {
            mainMenuButton.gameObject.SetActive(isActive);
        }

        if (restartButton != null)
        {
            restartButton.gameObject.SetActive(isActive); // Restart butonunu aktif/pasif yap
        }

        if (muteButton != null)
        {
            muteButton.gameObject.SetActive(isActive); // Mute butonunu aktif/pasif yap
        }

        if (unmuteButton != null)
        {
            unmuteButton.gameObject.SetActive(isActive); // Unmute butonunu aktif/pasif yap
        }
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Zamaný normal hýzýna geri al
        SceneManager.LoadScene("MenuScene"); // Ana menü sahnesini yükle
    }

    void RestartGame()
    {
        Time.timeScale = 1f; // Zamaný normal hýzýna geri al
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden yükle
    }

    void MuteSound()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = true; // Sesi kapat
        }
    }

    void UnmuteSound()
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.mute = false; // Sesi aç
        }
    }
}


