using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Slider ve Dropdown i�in gerekli
using TMPro;

public class SettingManager : MonoBehaviour
{
    public TextMeshProUGUI settingManager;
    public Slider volumeSlider; // Ses d�zeyi slider'�
    public TMP_Dropdown difficultyDropdown; // Zorluk ayarlar� i�in dropdown
    public GameObject settingsPanel; // Ayar paneli

    // Zorluk d�zeyine g�re engel spawn h�zlar�n� ayarlamak i�in
    public float easySpawnRate = 1.5f;
    public float mediumSpawnRate = 1.0f;
    public float hardSpawnRate = 0.5f;

    private void Start()
    {
        // Varsay�lan ayarlar� y�kle
        LoadSettings();

        // UI elementlerine listener ekle
        volumeSlider.onValueChanged.AddListener(SetVolume);
        difficultyDropdown.onValueChanged.AddListener(SetDifficulty);

        // Mevcut ayarlar� uygula
        ApplyDifficulty();
    }

    public void ToggleSettingsPanel()
    {
        // Ayar panelini a��p kapamak i�in
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void SetVolume(float volume)
    {
        // Ses d�zeyini ayarla
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume); // Ayar� kaydet
    }

    public void SetDifficulty(int difficultyIndex)
    {
        // Zorluk seviyesine g�re engel spawn h�z�n� ayarla ve kaydet
        float spawnRate = mediumSpawnRate;
        if (difficultyIndex == 0)
            spawnRate = easySpawnRate;
        else if (difficultyIndex == 2)
            spawnRate = hardSpawnRate;

        PlayerPrefs.SetFloat("SpawnRate", spawnRate); // Spawn h�z�n� kaydet
        PlayerPrefs.SetInt("Difficulty", difficultyIndex); // Zorluk seviyesini kaydet

        // Yeni ayar� hemen uygula
        ApplyDifficulty();
    }

    public void SetTimer(int timerIndex)
    {
        // Oyunun s�resini ayarla ve kaydet
        int gameDuration = timerIndex == 0 ? 60 : 90;
        PlayerPrefs.SetInt("GameDuration", gameDuration);
    }

    private void LoadSettings()
    {
        // Ses ayarlar�n� y�kle
        if (PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = volume;
            AudioListener.volume = volume;
        }

        // Zorluk ayarlar�n� y�kle
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            int difficultyIndex = PlayerPrefs.GetInt("Difficulty");
            difficultyDropdown.value = difficultyIndex;
        }

        // Oyun s�resi ayarlar�n� y�kle
        if (PlayerPrefs.HasKey("GameDuration"))
        {
            int gameDuration = PlayerPrefs.GetInt("GameDuration");
        }
    }

    private void ApplyDifficulty()
    {
        // Zorluk seviyesine g�re spawn h�z�n� uygula
        if (PlayerPrefs.HasKey("SpawnRate"))
        {
            float spawnRate = PlayerPrefs.GetFloat("SpawnRate");
            // Engellerin spawn h�z�n� buradan g�ncelleyebilirsiniz.
            // �rne�in: ObstacleSpawner.SetSpawnRate(spawnRate);
        }
    }
}
