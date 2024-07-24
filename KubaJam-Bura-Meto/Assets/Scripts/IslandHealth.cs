using UnityEngine;
using TMPro;
using System; // TextMeshPro i�in namespace

public class IslandHealth : MonoBehaviour
{
    public int health = 50; // Adan�n ba�lang�� sa�l���
    public TextMeshProUGUI healthText; // TextMeshPro UI referans�

    void Start()
    {
        // UI ba�lang�� sa�l��� ile g�ncellenir
        UpdateHealthUI();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Enemy")) // E�er �arp��an obje "Enemy" tag'ine sahipse
        {
            health -= 1; // Adan�n sa�l���n� 1 azalt
            Debug.Log("Island Health: " + health);

            // Sa�l�k UI'�n� g�ncelle
            UpdateHealthUI();

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

    // UI sa�l��� g�ncelleme fonksiyonu
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = Convert.ToString(health);
        }
    }
}
