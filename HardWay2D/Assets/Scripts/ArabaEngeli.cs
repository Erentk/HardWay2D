using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarObstacle : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        // Engel sola do�ru hareket eder
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        // E�er ekran�n d���na ��karsa yok olur
        if (transform.position.x < -10f)
        {
            Destroy(gameObject);
        }
    }
}

