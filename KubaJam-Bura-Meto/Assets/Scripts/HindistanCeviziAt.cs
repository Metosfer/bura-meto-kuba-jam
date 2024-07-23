using UnityEngine;

public class HindistanCeviziAt : MonoBehaviour
{
    public GameObject coconutPrefab; // Hindistan cevizi prefabi
    public Transform throwPoint; // Fýrlatma noktasý
    public float throwForce = 10f; // Fýrlatma kuvveti

    void Update()
    {
        // Space tuþuna basýldýðýnda hindistan cevizi fýrlatma
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowCoconut();
        }
    }

    void ThrowCoconut()
    {
        // Hindistan cevizini oluþtur ve fýrlat
        GameObject coconut = Instantiate(coconutPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = coconut.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);
    }
}
