using UnityEngine;
using UnityEngine.UI; // Slider'� kontrol etmek i�in

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maksimum can
    private int currentHealth; // Mevcut can
    public Slider healthSlider; // Slider referans�

    void Start()
    {
        currentHealth = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject); // D��man� yok et
        }
    }
}
