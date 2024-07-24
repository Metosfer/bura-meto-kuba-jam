using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] shipPrefabs; // Gemi prefablar�
    public Transform[] spawnPoints; // Spawn noktalar�
    public Transform islandTarget; // Adan�n transform referans�
    public float spawnInterval = 5f; // Gemi spawn aral��� (saniye)

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
        // Rastgele bir gemi prefab� se�
        int randomShipIndex = Random.Range(0, shipPrefabs.Length);
        GameObject shipPrefab = shipPrefabs[randomShipIndex];

        // Rastgele bir spawn noktas� se�
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomSpawnPointIndex];

        // Gemiyi olu�tur
        GameObject ship = Instantiate(shipPrefab, spawnPoint.position, spawnPoint.rotation);

        // Gemiye adan�n hedefini ayarla
        ShipMovement shipMovement = ship.GetComponent<ShipMovement>();
        if (shipMovement != null)
        {
            shipMovement.islandTarget = islandTarget;
        }
    }
}
