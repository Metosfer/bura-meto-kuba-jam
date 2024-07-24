using UnityEngine;
using TMPro; // TextMeshPro kullanýmý için

public class HindistanCeviziAt : MonoBehaviour
{
    public GameObject coconutPrefab; // Hindistan cevizi prefabi
    public Transform throwPoint; // Fýrlatma noktasý
    public float throwForce = 10f; // Fýrlatma kuvveti
    public Camera playerCamera; // Karakteri takip eden kamera referansý
    private Animator animator; // Animator bileþeni
    public bool isThrowing = false;
    public GameObject audioSourceObject; // Ses kaynaðýný içeren GameObject
    public TextMeshProUGUI coconutCountText; // TextMeshPro bileþeni

    private AudioSource audioSource; // Ses kaynaðý
    private int maxCoconuts = 30; // Baþlangýçta sahip olunan hindistan cevizi sayýsý
    private int currentCoconuts; // Mevcut hindistan cevizi sayýsý

    void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();

        // Ses kaynaðýný içeren GameObject'ten AudioSource bileþenini al
        if (audioSourceObject != null)
        {
            audioSource = audioSourceObject.GetComponent<AudioSource>();
        }
        else
        {
            Debug.LogError("AudioSource GameObject is not assigned.");
        }

        // Baþlangýçta hindistan cevizi sayýsýný ayarla
        currentCoconuts = maxCoconuts;
        UpdateCoconutCountText();
    }

    void Update()
    {
        // Space tuþuna basýldýðýnda hindistan cevizi fýrlatma
        if (Input.GetKeyDown(KeyCode.Space) && currentCoconuts > 0)
        {
            ThrowCoconut();
            isThrowing = true;
            // Animator'e throwing durumu gönder
            if (animator != null)
            {
                animator.SetBool("isThrowing", true);
            }
            currentCoconuts--;
            UpdateCoconutCountText();
        }
        // Space tuþuna basýlmadýðýnda throwing durumunu false yap
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
        // Hindistan cevizini oluþtur ve fýrlat
        GameObject coconut = Instantiate(coconutPrefab, throwPoint.position, throwPoint.rotation);
        Rigidbody rb = coconut.GetComponent<Rigidbody>();

        if (rb != null)
        {
            // Kameranýn bakýþ yönünü al
            Vector3 throwDirection = playerCamera.transform.forward;

            // Hindistan cevizini fýrlat
            rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);

            // Fýrlatma sesi çal
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
            // Mermi sayýsýný geri yükle
            currentCoconuts = maxCoconuts;
            UpdateCoconutCountText();
        }
    }

    private void OnTriggerEnter(Collider coconutPrefab)
    {
        // Hindistan cevizi bir "Enemy" tag'li objeye çarptýðýnda
        if (coconutPrefab.CompareTag("Enemy"))
        {
            // Skoru 100 arttýr
            currentCoconuts += 100;
            UpdateCoconutCountText();

            // Düþmaný yok et
            Destroy(coconutPrefab.gameObject);

            Destroy(coconutPrefab);

          
        }
    }
}
