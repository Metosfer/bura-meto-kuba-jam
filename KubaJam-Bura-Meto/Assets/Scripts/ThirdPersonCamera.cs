using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Karakterin transform referans�
    public float distance = 5.0f; // Kamera ile karakter aras�ndaki mesafe
    public float height = 2.0f; // Kamera y�ksekli�i
    public float rotationSpeed = 5.0f; // Kamera d�n�� h�z�
    public Vector2 rotationYLimits = new Vector2(-20, 80); // Y eksenindeki d�n�� s�n�rlar�

    private float rotationX = 0.0f; // X eksenindeki d�n�� a��s�
    private float rotationY = 0.0f; // Y eksenindeki d�n�� a��s�

    void Start()
    {
        // Kamera ba�lang�� rotasyonunu hedefin rotasyonuna ayarla
        Vector3 angles = transform.eulerAngles;
        rotationX = angles.y;
        rotationY = angles.x;
    }

    void LateUpdate()
    {
        if (target)
        {
            // Mouse hareketi ile rotasyon hesaplama
            rotationX += Input.GetAxis("Mouse X") * rotationSpeed;
            rotationY -= Input.GetAxis("Mouse Y") * rotationSpeed;
            rotationY = Mathf.Clamp(rotationY, rotationYLimits.x, rotationYLimits.y);

            // Hedef pozisyon ve rotasyonu hesaplama
            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
            Vector3 position = target.position - (rotation * Vector3.forward * distance + new Vector3(0, -height, 0));

            // Kameray� hedef pozisyon ve rotasyona ayarla
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
