using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 10f;
    public float slowDownFactor = 3f; // �arp��ma sonras� yava�lama fakt�r�
    public float slowDownDuration = 1f; // Yava�lama s�resi

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
        // H�z bilgisini konsola yazd�rma (iste�e ba�l�)
        Debug.Log($"Current Speed: {rb.velocity.magnitude}");

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Engellere �arpma kontrol�
        {
            if (!isSlowed)
            {
                rb.velocity *= slowDownFactor; // �arp��ma sonras� h�z azaltma
                isSlowed = true;
                slowDownTimer = slowDownDuration; // Yava�lama s�resi ba�latma

                // �arp��ma an�nda bilgileri konsola yazd�rma
                Debug.Log($"Collision detected! Speed reduced to: {rb.velocity.magnitude}");
                Debug.Log($"Slowdown duration: {slowDownDuration} seconds");
            }
        }
    }

    void Update()
    {
        // Yava�lama s�resi ge�tikten sonra tekrar normal h�z
        if (isSlowed)
        {
            slowDownTimer -= Time.deltaTime;
            if (slowDownTimer <= 0)
            {
                isSlowed = false;

                // Yava�lama s�resi bitti�inde bilgileri konsola yazd�rma
                Debug.Log("Slowdown effect ended. Returning to normal speed.");
            }
        }
    }
}



