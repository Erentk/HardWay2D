using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCrashSound : MonoBehaviour
{
    public AudioSource collisionAudioSource; // �arpma ses kayna��

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) // Engelle �arp��ma
        {
            // Ses efekti �al
            if (collisionAudioSource != null)
            {
                collisionAudioSource.Play();
            }
        }
    }
}
