using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Karakterin hareket hýzý
    public float rotationSpeed = 700.0f; // Karakterin dönüþ hýzý
    public Camera playerCamera; // Karakteri takip eden kamera referansý

    private Vector3 movement;
    private Animator animator;
    private bool cursorLocked = true;
    public AudioSource audioSource; // Ses kaynaðý

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // AudioSource bileþenini alýyoruz
        LockCursor();
    }

    void Update()
    {
        // ESC tuþuna basýldýðýnda cursor kilidini deðiþtir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLocked = !cursorLocked;
            if (cursorLocked)
            {
                LockCursor();
            }
            else
            {
                UnlockCursor();
            }
        }
    }

    void FixedUpdate()
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
            animator.SetBool("isWalking", true);

            // Hareket ediyorsa sesi çal
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            animator.SetBool("isWalking", false);

            // Hareket etmiyorsa sesi durdur
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    void MoveCharacter()
    {
        // Kameranýn ileri yönünü ve sað yönünü al
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // Yükseklik bileþenlerini sýfýrla
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Hareket yönünü kameraya göre hesapla
        Vector3 desiredMoveDirection = forward * movement.z + right * movement.x;

        // Karakteri hareket ettir
        transform.Translate(desiredMoveDirection * speed * Time.deltaTime, Space.World);

        // Karakterin dönmesini saðla
        Quaternion toRotation = Quaternion.LookRotation(desiredMoveDirection, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
