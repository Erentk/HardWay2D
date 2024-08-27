using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioSource buttonAudioSource; // Butonun ses kayna��

    void Start()
    {
        // Buton bile�enini al ve bir t�klama olay�na abone ol
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlaySound);
        }
        else
        {
            Debug.LogError("Button component not found on this GameObject.");
        }

        // buttonAudioSource referans�n�n atan�p atanmad���n� kontrol et
        if (buttonAudioSource == null)
        {
            Debug.LogError("ButtonAudioSource is not assigned in the Inspector.");
        }
    }

    public void PlaySound()
    {
        // Buton sesi �al
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
