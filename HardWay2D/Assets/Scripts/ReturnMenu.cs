using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        // Ana men� sahnesinin ismini yaz�n
        SceneManager.LoadScene("MenuScene");
    }
}
