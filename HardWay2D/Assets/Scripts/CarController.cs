using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed = 5f; // Arabanýn hareket hýzý

    void Update()
    {
        // Engel arabanýn Y ekseninde aþaðý doðru hareket etmesi
        transform.Translate(0, -moveSpeed * Time.deltaTime, 0);
    }
}

