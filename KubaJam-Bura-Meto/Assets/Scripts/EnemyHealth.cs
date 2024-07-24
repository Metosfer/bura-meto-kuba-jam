using UnityEngine;
using UnityEngine.UI; // Slider'� kontrol etmek i�in

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maksimum can
    private int currentHealth; // Mevcut can
    

    void Start()
    {
        currentHealth = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;


        if (currentHealth <= 0)
        {
            Debug.Log("Obje Yok edildi");
            Destroy(gameObject); // D��man� yok et
        }
    }
}
