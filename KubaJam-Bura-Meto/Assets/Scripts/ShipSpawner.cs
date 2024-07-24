using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] shipPrefabs; // Gemi prefablar�
    public Transform[] spawnPoints; // Spawn noktalar�
    public Transform islandTarget; // Adan�n transform referans�
    public float spawnInterval = 5f; // Ba�lang�� gemi spawn aral��� (saniye)
    public float intervalDecrease = 0.5f; // Aral���n her 15 saniyede azalaca�� miktar
    public float decreaseInterval = 15f; // Aral���n azalaca�� s�re (saniye)

    private float timer;
    private float decreaseTimer;

    void Update()
    {
        timer += Time.deltaTime;
        decreaseTimer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnShip();
            timer = 0f;
        }

        if (decreaseTimer >= decreaseInterval)
        {
            // Spawn aral���n� azalt
            spawnInterval = Mathf.Max(1f, spawnInterval - intervalDecrease); // Minumum 1 saniye olarak s�n�rla
            decreaseTimer = 0f;
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
