using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f; // Karakterin hareket h�z�
    public float rotationSpeed = 700.0f; // Karakterin d�n�� h�z�
    private Vector3 movement;

    void Update()
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
        }
    }

    void MoveCharacter()
    {
        // Karakteri hareket ettir
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // Karakterin d�nmesini sa�la
        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
    }
}
