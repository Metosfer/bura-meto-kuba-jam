using UnityEngine;
using TMPro;
using System; // TextMeshPro için namespace

public class IslandHealth : MonoBehaviour
{
    public int health = 50; // Adanýn baþlangýç saðlýðý
    public TextMeshProUGUI healthText; // TextMeshPro UI referansý

    void Start()
    {
        // UI baþlangýç saðlýðý ile güncellenir
        UpdateHealthUI();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision detected with: " + other.gameObject.name);

        if (other.CompareTag("Enemy")) // Eðer çarpýþan obje "Enemy" tag'ine sahipse
        {
            health -= 1; // Adanýn saðlýðýný 1 azalt
            Debug.Log("Island Health: " + health);

            // Saðlýk UI'ýný güncelle
            UpdateHealthUI();

            if (health <= 0)
            {
                Debug.Log("Game Over");
                // Buraya oyun bitirme kodlarý eklenebilir
                // Örneðin, oyunu durdurmak için:
                // Time.timeScale = 0; // Oyunu durdur
                // veya
                // Application.Quit(); // Oyunu kapat
            }

            Destroy(other.gameObject); // Gemi objesini yok et
        }
    }

    // UI saðlýðý güncelleme fonksiyonu
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = Convert.ToString(health);
        }
    }
}
