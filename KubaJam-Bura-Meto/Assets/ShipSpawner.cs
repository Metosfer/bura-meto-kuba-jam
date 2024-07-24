using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] shipPrefabs; // Gemi prefablarý
    public Transform[] spawnPoints; // Spawn noktalarý
    public float spawnInterval = 5f; // Gemi spawn aralýðý (saniye)

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnShip();
            timer = 0f;
        }
    }

    void SpawnShip()
    {
        // Rastgele bir gemi prefabý seç
        int randomShipIndex = Random.Range(0, shipPrefabs.Length);
        GameObject shipPrefab = shipPrefabs[randomShipIndex];

        // Rastgele bir spawn noktasý seç
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

        // Gemiyi oluþtur
        Instantiate(shipPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
