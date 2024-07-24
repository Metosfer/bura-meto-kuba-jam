using UnityEngine;

public class IslandHealth : MonoBehaviour
{
    public int health = 10; // Adan�n ba�lang�� sa�l���

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Enemy")) // E�er �arp��an obje "Enemy" tag'ine sahipse
        {
            health -= 1; // Adan�n sa�l���n� 1 azalt
            Debug.Log("Island Health: " + health);

            if (health <= 0)
            {
                Debug.Log("Game Over");
                // Buraya oyun bitirme kodlar� eklenebilir
                // �rne�in, oyunu durdurmak i�in:
                // Time.timeScale = 0; // Oyunu durdur
                // veya
                // Application.Quit(); // Oyunu kapat
            }

            Destroy(other.gameObject); // Gemi objesini yok et
        }
    }
}

