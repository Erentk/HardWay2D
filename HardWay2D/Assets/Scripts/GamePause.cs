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

    // Ses butonlar�
    public Button muteButton; // Sesi kapatma butonu
    public Button unmuteButton; // Sesi a�ma butonu

    void Start()
    {
        // Ba�lang��ta pause UI'� kapal� yap
        SetPauseUIActive(false);

        // MainMenu butonuna t�klama olay�n� ekle
        if (mainMenuButton != null)
        {
            mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        }

        // Restart butonuna t�klama olay�n� ekle
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }

        // Mute ve Unmute butonlar�na t�klama olaylar�n� ekle
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
        // Space tu�una bas�ld���nda
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
        SetPauseUIActive(true); // Pause UI'� a�

        // Background m�zi�i durdur
        if (backgroundMusic != null)
        {
            backgroundMusic.Pause();
        }
    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Oyunu devam ettir
        isPaused = false;
        SetPauseUIActive(false); // Pause UI'� kapat

        // Background m�zi�i devam ettir
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
        Time.timeScale = 1f; // Zaman� normal h�z�na geri al
        SceneManager.LoadScene("MenuScene"); // Ana men� sahnesini y�kle
    }

    void RestartGame()
    {
        Time.timeScale = 1f; // Zaman� normal h�z�na geri al
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Mevcut sahneyi yeniden y�kle
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
            backgroundMusic.mute = false; // Sesi a�
        }
    }
}


