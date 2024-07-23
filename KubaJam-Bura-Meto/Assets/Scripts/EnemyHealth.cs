using UnityEngine;
using UnityEngine.UI; // Slider'ý kontrol etmek için

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // Maksimum can
    private int currentHealth; // Mevcut can
    public Slider healthSlider; // Slider referansý

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
            Destroy(gameObject); // Düþmaný yok et
        }
    }
}
