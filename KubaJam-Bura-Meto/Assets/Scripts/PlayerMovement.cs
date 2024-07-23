using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Karakterin hareket hýzý
    public float rotationSpeed = 700.0f; // Karakterin dönüþ hýzý
    private Vector3 movement;
    private Animator animator; // Animator bileþeni

    void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Input alýyoruz
        float horizontal = Input.GetAxis("Horizontal"); // A ve D tuþlarý için
        float vertical = Input.GetAxis("Vertical"); // W ve S tuþlarý için

        // Hareket vektörünü oluþturuyoruz
        movement = new Vector3(horizontal, 0, vertical).normalized;

        // Eðer bir hareket girdisi varsa karakteri hareket ettir ve döndür
        if (movement.magnitude > 0.1f)
        {
            MoveCharacter();
            // Animator'e hareket durumu gönder
            if (animator != null)
            {
                animator.SetBool("isWalking", true);
            }
        }
        else
        {
            // Animator'e hareket durumu gönder
            if (animator != null)
            {
                animator.SetBool("isWalking", false);
            }
        }
    }

    void MoveCharacter()
    {
        // Karakteri hareket ettir
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Karakterin dönmesini saðla
        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
