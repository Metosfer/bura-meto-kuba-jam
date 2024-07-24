using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject[] shipPrefabs; // Gemi prefablarý
    public Transform[] spawnPoints; // Spawn noktalarý
    public Transform islandTarget; // Adanýn transform referansý
    public float spawnInterval = 5f; // Baþlangýç gemi spawn aralýðý (saniye)
    public float intervalDecrease = 0.5f; // Aralýðýn her 15 saniyede azalacaðý miktar
    public float decreaseInterval = 15f; // Aralýðýn azalacaðý süre (saniye)

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
            // Spawn aralýðýný azalt
            spawnInterval = Mathf.Max(1f, spawnInterval - intervalDecrease); // Minumum 1 saniye olarak sýnýrla
            decreaseTimer = 0f;
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
        GameObject ship = Instantiate(shipPrefab, spawnPoint.position, spawnPoint.rotation);

        // Gemiye adanýn hedefini ayarla
        ShipMovement shipMovement = ship.GetComponent<ShipMovement>();
        if (shipMovement != null)
        {
            shipMovement.islandTarget = islandTarget;
        }
    }
}
