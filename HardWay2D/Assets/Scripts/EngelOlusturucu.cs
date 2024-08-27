using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelOlusturucu : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  // Birden fazla engel prefab'�
    public float spawnInterval = 1f;      // Engel olu�turma s�resi
    public float xMin = -2f;              // X eksenindeki minimum s�n�r
    public float xMax = 0.5f;             // X eksenindeki maksimum s�n�r
    public float spawnHeightMin = 4f;     // Y eksenindeki minimum spawn y�ksekli�i
    public float spawnHeightMax = 4.5f;   // Y eksenindeki maksimum spawn y�ksekli�i

    private float spawnRate;

    void Start()
    {
        // Ba�lang��ta zorluk seviyesine g�re spawn h�z�n� ayarla
        LoadSpawnRate();

        // Engel olu�turma i�lemini ba�lat
        InvokeRepeating("SpawnObstacle", spawnRate, spawnRate);
    }

    void LoadSpawnRate()
    {
        // PlayerPrefs'ten zorluk seviyesine g�re spawn h�z�n� y�kle
        if (PlayerPrefs.HasKey("SpawnRate"))
        {
            spawnRate = PlayerPrefs.GetFloat("SpawnRate");
        }
        else
        {
            // E�er ayar kaydedilmediyse varsay�lan spawnInterval kullan�l�r
            spawnRate = spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        // Rastgele bir X pozisyonu belirle (xMin ve xMax aras�nda)
        float spawnX = Random.Range(xMin, xMax);

        // Rastgele bir Y pozisyonu belirle (spawnHeightMin ve spawnHeightMax aras�nda)
        float spawnY = Random.Range(spawnHeightMin, spawnHeightMax);

        // Spawn pozisyonunu belirle
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Rastgele bir prefab se�
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        // Engeli olu�tur
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}




