using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Slider ve Dropdown için gerekli
using TMPro;

public class SettingManager : MonoBehaviour
{
    public TextMeshProUGUI settingManager;
    public Slider volumeSlider; // Ses düzeyi slider'ý
    public TMP_Dropdown difficultyDropdown; // Zorluk ayarlarý için dropdown
    public GameObject settingsPanel; // Ayar paneli

    // Zorluk düzeyine göre engel spawn hýzlarýný ayarlamak için
    public float easySpawnRate = 1.5f;
    public float mediumSpawnRate = 1.0f;
    public float hardSpawnRate = 0.5f;

    private void Start()
    {
        // Varsayýlan ayarlarý yükle
        LoadSettings();

        // UI elementlerine listener ekle
        volumeSlider.onValueChanged.AddListener(SetVolume);
        difficultyDropdown.onValueChanged.AddListener(SetDifficulty);

        // Mevcut ayarlarý uygula
        ApplyDifficulty();
    }

    public void ToggleSettingsPanel()
    {
        // Ayar panelini açýp kapamak için
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void SetVolume(float volume)
    {
        // Ses düzeyini ayarla
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("Volume", volume); // Ayarý kaydet
    }

    public void SetDifficulty(int difficultyIndex)
    {
        // Zorluk seviyesine göre engel spawn hýzýný ayarla ve kaydet
        float spawnRate = mediumSpawnRate;
        if (difficultyIndex == 0)
            spawnRate = easySpawnRate;
        else if (difficultyIndex == 2)
            spawnRate = hardSpawnRate;

        PlayerPrefs.SetFloat("SpawnRate", spawnRate); // Spawn hýzýný kaydet
        PlayerPrefs.SetInt("Difficulty", difficultyIndex); // Zorluk seviyesini kaydet

        // Yeni ayarý hemen uygula
        ApplyDifficulty();
    }

    public void SetTimer(int timerIndex)
    {
        // Oyunun süresini ayarla ve kaydet
        int gameDuration = timerIndex == 0 ? 60 : 90;
        PlayerPrefs.SetInt("GameDuration", gameDuration);
    }

    private void LoadSettings()
    {
        // Ses ayarlarýný yükle
        if (PlayerPrefs.HasKey("Volume"))
        {
            float volume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = volume;
            AudioListener.volume = volume;
        }

        // Zorluk ayarlarýný yükle
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            int difficultyIndex = PlayerPrefs.GetInt("Difficulty");
            difficultyDropdown.value = difficultyIndex;
        }

        // Oyun süresi ayarlarýný yükle
        if (PlayerPrefs.HasKey("GameDuration"))
        {
            int gameDuration = PlayerPrefs.GetInt("GameDuration");
        }
    }

    private void ApplyDifficulty()
    {
        // Zorluk seviyesine göre spawn hýzýný uygula
        if (PlayerPrefs.HasKey("SpawnRate"))
        {
            float spawnRate = PlayerPrefs.GetFloat("SpawnRate");
            // Engellerin spawn hýzýný buradan güncelleyebilirsiniz.
            // Örneðin: ObstacleSpawner.SetSpawnRate(spawnRate);
        }
    }
}
