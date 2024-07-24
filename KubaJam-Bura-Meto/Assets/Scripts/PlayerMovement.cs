using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Karakterin hareket h�z�
    public float rotationSpeed = 700.0f; // Karakterin d�n�� h�z�
    public Camera playerCamera; // Karakteri takip eden kamera referans�

    private Vector3 movement;
    private Animator animator;
    private bool cursorLocked = true;
    public AudioSource audioSource; // Ses kayna��

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // AudioSource bile�enini al�yoruz
        LockCursor();
    }

    void Update()
    {
        // ESC tu�una bas�ld���nda cursor kilidini de�i�tir
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
        // Input al�yoruz
        float horizontal = Input.GetAxis("Horizontal"); // A ve D tu�lar� i�in
        float vertical = Input.GetAxis("Vertical"); // W ve S tu�lar� i�in

        // Hareket vekt�r�n� olu�turuyoruz
        movement = new Vector3(horizontal, 0, vertical).normalized;

        // E�er bir hareket girdisi varsa karakteri hareket ettir ve d�nd�r
        if (movement.magnitude > 0.1f)
        {
            MoveCharacter();
            animator.SetBool("isWalking", true);

            // Hareket ediyorsa sesi �al
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
        // Kameran�n ileri y�n�n� ve sa� y�n�n� al
        Vector3 forward = playerCamera.transform.forward;
        Vector3 right = playerCamera.transform.right;

        // Y�kseklik bile�enlerini s�f�rla
        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Hareket y�n�n� kameraya g�re hesapla
        Vector3 desiredMoveDirection = forward * movement.z + right * movement.x;

        // Karakteri hareket ettir
        transform.Translate(desiredMoveDirection * speed * Time.deltaTime, Space.World);

        // Karakterin d�nmesini sa�la
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
