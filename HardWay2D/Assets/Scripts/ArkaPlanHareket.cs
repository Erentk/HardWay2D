using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanHareket : MonoBehaviour
{
    public float scrollSpeed = 0.5f; // H�z� art�rabilirsiniz
    public float height = 10f; // Arka plan�n y�ksekli�i
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, height);
        transform.position = startPosition + Vector3.down * newPosition;
    }
}



