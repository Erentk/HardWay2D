using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f; // Araban�n hareket h�z�

    void Update()
    {
        // Engel araban�n Y ekseninde a�a�� do�ru hareket etmesi
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }
}

