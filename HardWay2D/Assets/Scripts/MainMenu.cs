using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Yeni oyuna baþlamak için
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene"); // Oyunun baþladýðý sahne ismi
    }

    // Ayarlar menüsünü açmak için
    public void OpenSettings()
    {
        // Ayarlar sahnesine geçiþ yapabilirsiniz
    }

    // Oyunu kapatmak için
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // Uygulamayý kapat
#endif
    }
}
