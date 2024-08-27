using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngelOlusturucu : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;  // Birden fazla engel prefab'ý
    public float spawnInterval = 1f;      // Engel oluþturma süresi
    public float xMin = -2f;              // X eksenindeki minimum sýnýr
    public float xMax = 0.5f;             // X eksenindeki maksimum sýnýr
    public float spawnHeightMin = 4f;     // Y eksenindeki minimum spawn yüksekliði
    public float spawnHeightMax = 4.5f;   // Y eksenindeki maksimum spawn yüksekliði

    private float spawnRate;

    void Start()
    {
        // Baþlangýçta zorluk seviyesine göre spawn hýzýný ayarla
        LoadSpawnRate();

        // Engel oluþturma iþlemini baþlat
        InvokeRepeating("SpawnObstacle", spawnRate, spawnRate);
    }

    void LoadSpawnRate()
    {
        // PlayerPrefs'ten zorluk seviyesine göre spawn hýzýný yükle
        if (PlayerPrefs.HasKey("SpawnRate"))
        {
            spawnRate = PlayerPrefs.GetFloat("SpawnRate");
        }
        else
        {
            // Eðer ayar kaydedilmediyse varsayýlan spawnInterval kullanýlýr
            spawnRate = spawnInterval;
        }
    }

    void SpawnObstacle()
    {
        // Rastgele bir X pozisyonu belirle (xMin ve xMax arasýnda)
        float spawnX = Random.Range(xMin, xMax);

        // Rastgele bir Y pozisyonu belirle (spawnHeightMin ve spawnHeightMax arasýnda)
        float spawnY = Random.Range(spawnHeightMin, spawnHeightMax);

        // Spawn pozisyonunu belirle
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Rastgele bir prefab seç
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);
        GameObject selectedPrefab = obstaclePrefabs[randomIndex];

        // Engeli oluþtur
        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}




