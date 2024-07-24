using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Karakterin transform referansý
    public float distance = 5.0f; // Kamera ile karakter arasýndaki mesafe
    public float height = 2.0f; // Kamera yüksekliði
    public float rotationSpeed = 5.0f; // Kamera dönüþ hýzý
    public Vector2 rotationYLimits = new Vector2(-20, 80); // Y eksenindeki dönüþ sýnýrlarý

    private float rotationX = 0.0f; // X eksenindeki dönüþ açýsý
    private float rotationY = 0.0f; // Y eksenindeki dönüþ açýsý

    void Start()
    {
        // Kamera baþlangýç rotasyonunu hedefin rotasyonuna ayarla
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

            // Kamerayý hedef pozisyon ve rotasyona ayarla
            transform.rotation = rotation;
            transform.position = position;
        }
    }
}
