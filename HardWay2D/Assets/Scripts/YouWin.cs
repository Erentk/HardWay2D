using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro kullanýyorsanýz

public class YouWin : MonoBehaviour
{
    public TextMeshProUGUI winText; // Kazanma mesajý için TextMeshPro UI referansý

    void Start()
    {
        // Baþlangýçta kazanma mesajýný gizle
        if (winText != null)
        {
            winText.gameObject.SetActive(false);
        }
    }

    public void ShowWinMessage()
    {
        if (winText != null)
        {
            winText.gameObject.SetActive(true); // Kazanma mesajýný göster
        }
    }
}

