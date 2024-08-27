using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro kullan�yorsan�z

public class YouWin : MonoBehaviour
{
    public TextMeshProUGUI winText; // Kazanma mesaj� i�in TextMeshPro UI referans�

    void Start()
    {
        // Ba�lang��ta kazanma mesaj�n� gizle
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }

    public void ShowWinMessage()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(true); // Kazanma mesaj�n� g�ster
        }
    }
}

