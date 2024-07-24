using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Transform islandTarget; // Adan�n transform referans�
    public float speed = 5f; // Gemi hareket h�z�

    void Update()
    {
        if (islandTarget != null)
        {
            // Adaya do�ru y�nelme
            Vector3 direction = (islandTarget.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Adaya do�ru d�nme
            // Quaternion lookRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
}