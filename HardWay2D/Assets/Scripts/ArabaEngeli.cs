using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacle : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Engel sola doðru hareket eder
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // Eðer ekranýn dýþýna çýkarsa yok olur
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}

