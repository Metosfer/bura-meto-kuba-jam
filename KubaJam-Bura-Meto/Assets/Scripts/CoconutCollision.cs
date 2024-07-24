using UnityEngine;

public class CoconutCollision : MonoBehaviour
{
    public int damage = 1; // Hindistan cevizi hasar miktar�

    void OnTriggerEnter(Collider collider)
    {
        // E�er �arp��ma "Enemy" tag'li bir obje ile ger�ekle�irse
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
