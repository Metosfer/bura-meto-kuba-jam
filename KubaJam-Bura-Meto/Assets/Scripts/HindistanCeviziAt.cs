using UnityEngine;

public class HindistanCeviziAt : MonoBehaviour
{
    public GameObject coconutPrefab; // Hindistan cevizi prefabi
    public Transform throwPoint; // Fýrlatma noktasý
    public float throwForce = 10f; // Fýrlatma kuvveti
    private Animator animator; // Animator bileþeni

    void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Space tuþuna basýldýðýnda hindistan cevizi fýrlatma
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowCoconut();
            // Animator'e throwing durumu gönder
            if (animator != null)
            {
                animator.SetBool("isThrowing", true);
            }
        }
        // Space tuþuna basýlmadýðýnda throwing durumunu false yap
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (animator != null)
            {
                animator.SetBool("isThrowing", false);
            }
        }
    }

    public void ThrowCoconut()
    {
        // Hindistan cevizini oluþtur ve fýrlat
        GameObject coconut = Instantiate(coconutPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = coconut.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);

        // Hindistan cevizini 5 saniye sonra yok et
        Destroy(coconut, 5f);
    }
}
