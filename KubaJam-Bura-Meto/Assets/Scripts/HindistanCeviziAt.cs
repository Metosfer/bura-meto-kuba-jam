using UnityEngine;
using TMPro; // TextMeshPro kullan�m� i�in

public class HindistanCeviziAt : MonoBehaviour
{
    public GameObject coconutPrefab; // Hindistan cevizi prefabi
    public Transform throwPoint; // F�rlatma noktas�
    public float throwForce = 10f; // F�rlatma kuvveti
    public Camera playerCamera; // Karakteri takip eden kamera referans�
    private Animator animator; // Animator bile�eni
    public bool isThrowing = false;
    public GameObject audioSourceObject; // Ses kayna��n� i�eren GameObject
    public TextMeshProUGUI coconutCountText; // TextMeshPro bile�eni

    private AudioSource audioSource; // Ses kayna��
    private int maxCoconuts = 30; // Ba�lang��ta sahip olunan hindistan cevizi say�s�
    private int currentCoconuts; // Mevcut hindistan cevizi say�s�

    void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();

        // Ses kayna��n� i�eren GameObject'ten AudioSource bile�enini al
        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("AudioSource GameObject is not assigned.");
        }

        // Ba�lang��ta hindistan cevizi say�s�n� ayarla
        currentCoconuts = maxCoconuts;
        UpdateCoconutCountText();
    }

    void Update()
    {
        // Space tu�una bas�ld���nda hindistan cevizi f�rlatma
        if (Input.GetKeyDown(KeyCode.Space) && currentCoconuts > 0)
        {
            ThrowCoconut();
            isThrowing = true;
            // Animator'e throwing durumu g�nder
            if (animator != null)
            {
                animator.SetBool("isThrowing", true);
            }
            currentCoconuts--;
            UpdateCoconutCountText();
        }
        // Space tu�una bas�lmad���nda throwing durumunu false yap
        else if (Input.GetKeyUp(KeyCode.Space))
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

        if (rb != null)
        {
            // Kameran�n bak�� y�n�n� al
            Vector3 throwDirection = playerCamera.transform.forward;

            // Hindistan cevizini f�rlat
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            // F�rlatma sesi �al
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();
            }

            // Hindistan cevizini 5 saniye sonra yok et
            Destroy(coconut, 5f);
        }
    }

    private void UpdateCoconutCountText()
    {
        if (coconutCountText != null)
        {
            coconutCountText.text = $"{currentCoconuts}/{maxCoconuts}";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tree"))
        {
            // Mermi say�s�n� geri y�kle
            currentCoconuts = maxCoconuts;
            UpdateCoconutCountText();
        }
    }

    private void OnTriggerEnter(Collider coconutPrefab)
    {
        // Hindistan cevizi bir "Enemy" tag'li objeye �arpt���nda
        if (coconutPrefab.CompareTag("Enemy"))
        {
            // Skoru 100 artt�r
            currentCoconuts += 100;
            UpdateCoconutCountText();

            // D��man� yok et
            Destroy(coconutPrefab.gameObject);

            Destroy(coconutPrefab);

          
        }
    }
}
