using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashSound : MonoBehaviour
{
    public AudioSource collisionAudioSource; // Çarpma ses kaynaðý

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Engelle çarpýþma
        {
            // Ses efekti çal
            if (collisionAudioSource != null)
            {
                collisionAudioSource.Play();
            }
        }
    }
}
