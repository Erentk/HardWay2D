using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioToggle : MonoBehaviour
{
    public Button muteButton;
    public Button unmuteButton;

    private bool isMuted = false;

    void Start()
    {
        // Baþlangýç durumunu güncelle
        UpdateAudioState();

        // Butonlara listener ekle
        muteButton.onClick.AddListener(MuteAudio);
        unmuteButton.onClick.AddListener(UnmuteAudio);
    }

    void MuteAudio()
    {
        isMuted = true;
        AudioListener.pause = true; // Sesi kapat
        UpdateButtonVisibility(); // Buton görünürlüðünü güncelle
    }

    void UnmuteAudio()
    {
        isMuted = false;
        AudioListener.pause = false; // Sesi aç
        UpdateButtonVisibility(); // Buton görünürlüðünü güncelle
    }

    void UpdateButtonVisibility()
    {
        muteButton.interactable = !isMuted;
        unmuteButton.interactable = isMuted;
    }

    void UpdateAudioState()
    {
        // Baþlangýçta sesin durumuna göre butonlarý ayarla
        AudioListener.pause = isMuted;
        UpdateButtonVisibility();
    }
}
