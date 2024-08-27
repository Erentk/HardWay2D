using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMenu : MonoBehaviour
{
    public void ReturnToMainMenu()
    {
        // Ana menü sahnesinin ismini yazýn
        SceneManager.LoadScene("MenuScene");
    }
}
