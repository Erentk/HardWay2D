using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Yeni oyuna ba�lamak i�in
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Oyunun ba�lad��� sahne ismi
    }

    // Ayarlar men�s�n� a�mak i�in
    public void OpenSettings()
    {
        // Ayarlar sahnesine ge�i� yapabilirsiniz
    }

    // Oyunu kapatmak i�in
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Uygulamay� kapat
#endif
    }
}
