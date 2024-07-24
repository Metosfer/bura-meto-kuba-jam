using UnityEngine;

public class CoconutCollision : MonoBehaviour
{
    public int damage = 1; // Hindistan cevizi hasar miktarý

    void OnTriggerEnter(Collider collider)
    {
        // Eðer çarpýþma "Enemy" tag'li bir obje ile gerçekleþirse
        if (collider.CompareTag("Enemy"))
        {


            EnemyHealth enemyHealth = collider.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }

            // Hindistan cevizini yok et
            Destroy(gameObject);
        }
        else
        {
            // Hindistan cevizini 5 saniye sonra yok et
            Destroy(gameObject, 5f);
        }
    }
}
