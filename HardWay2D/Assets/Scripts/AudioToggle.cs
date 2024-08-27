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
        // Ba�lang�� durumunu g�ncelle
        UpdateAudioState();

        // Butonlara listener ekle
        muteButton.onClick.AddListener(MuteAudio);
        unmuteButton.onClick.AddListener(UnmuteAudio);
    }

    void MuteAudio()
    {
        isMuted = true;
        AudioListener.pause = true; // Sesi kapat
        UpdateButtonVisibility(); // Buton g�r�n�rl���n� g�ncelle
    }

    void UnmuteAudio()
    {
        isMuted = false;
        AudioListener.pause = false; // Sesi a�
        UpdateButtonVisibility(); // Buton g�r�n�rl���n� g�ncelle
    }

    void UpdateButtonVisibility()
    {
        muteButton.interactable = !isMuted;
        unmuteButton.interactable = isMuted;
    }

    void UpdateAudioState()
    {
        // Ba�lang��ta sesin durumuna g�re butonlar� ayarla
        AudioListener.pause = isMuted;
        UpdateButtonVisibility();
    }
}
