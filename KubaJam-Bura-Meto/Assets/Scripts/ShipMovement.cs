using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Transform islandTarget; // Adanýn transform referansý
    public float speed = 5f; // Gemi hareket hýzý

    void Update()
    {
        if (islandTarget != null)
        {
            // Adaya doðru yönelme
            Vector3 direction = (islandTarget.position - transform.position).normalized;
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Adaya doðru dönme
            // Quaternion lookRotation = Quaternion.LookRotation(direction);
            //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * speed);
        }
    }
}