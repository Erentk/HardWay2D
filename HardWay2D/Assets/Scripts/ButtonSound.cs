using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonAudioSource; // Butonun ses kaynaðý

    void Start()
    {
        // Buton bileþenini al ve bir týklama olayýna abone ol
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }

        // buttonAudioSource referansýnýn atanýp atanmadýðýný kontrol et
        if (buttonAudioSource == null)
        {
            Debug.LogError("ButtonAudioSource is not assigned in the Inspector.");
        }
    }

    public void PlaySound()
    {
        // Buton sesi çal
        if (buttonAudioSource != null)
        {
            buttonAudioSource.Play();
        }
        else
        {
            Debug.LogError("ButtonAudioSource is not assigned.");
        }
    }
}
