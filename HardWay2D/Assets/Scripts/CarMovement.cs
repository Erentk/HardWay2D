using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f;
    public float slowDownFactor = 3f; // Çarpýþma sonrasý yavaþlama faktörü
    public float slowDownDuration = 1f; // Yavaþlama süresi

    private Rigidbody2D rb;
    private bool isSlowed = false;
    private float slowDownTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

        // Sadece x ekseninde hareket etme
        if (!isSlowed)
        {
            rb.velocity = new Vector2(move * speed, rb.velocity.y);
        }
        // Hýz bilgisini konsola yazdýrma (isteðe baðlý)
        Debug.Log($"Current Speed: {rb.velocity.magnitude}");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Engellere çarpma kontrolü
        {
            if (!isSlowed)
            {
                rb.velocity *= slowDownFactor; // Çarpýþma sonrasý hýz azaltma
                isSlowed = true;
                slowDownTimer = slowDownDuration; // Yavaþlama süresi baþlatma

                // Çarpýþma anýnda bilgileri konsola yazdýrma
                Debug.Log($"Collision detected! Speed reduced to: {rb.velocity.magnitude}");
                Debug.Log($"Slowdown duration: {slowDownDuration} seconds");
            }
        }
    }

    void Update()
    {
        // Yavaþlama süresi geçtikten sonra tekrar normal hýz
        if (isSlowed)
        {
            slowDownTimer -= Time.deltaTime;
            if (slowDownTimer <= 0)
            {
                isSlowed = false;

                // Yavaþlama süresi bittiðinde bilgileri konsola yazdýrma
                Debug.Log("Slowdown effect ended. Returning to normal speed.");
            }
        }
    }
}



