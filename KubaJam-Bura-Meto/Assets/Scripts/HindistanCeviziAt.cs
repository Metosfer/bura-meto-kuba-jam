using UnityEngine;

public class HindistanCeviziAt : MonoBehaviour
{
    public GameObject coconutPrefab; // Hindistan cevizi prefabi
    public Transform throwPoint; // F�rlatma noktas�
    public float throwForce = 10f; // F�rlatma kuvveti
    private Animator animator; // Animator bile�eni
    public bool isThrowing = false;
    void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Space tu�una bas�ld���nda hindistan cevizi f�rlatma
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowCoconut();
            isThrowing = true;
            // Animator'e throwing durumu g�nder
            if (animator != null)
            {
                animator.SetBool("isThrowing", true);
            }
        }
        // Space tu�una bas�lmad���nda throwing durumunu false yap
        else
        {
            if (animator != null)
            {
                animator.SetBool("isThrowing", false);
            }
            isThrowing = false;
        }
    }

    public void ThrowCoconut()
    {
        // Hindistan cevizini olu�tur ve f�rlat
        GameObject coconut = Instantiate(coconutPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = coconut.GetComponent<Rigidbody>();
        rb.AddForce(throwPoint.forward * throwForce, ForceMode.Impulse);

        // Hindistan cevizini 5 saniye sonra yok et
        Destroy(coconut, 5f);
    }
}
