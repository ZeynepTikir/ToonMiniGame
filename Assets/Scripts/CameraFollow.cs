using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Takip edilecek obje (Player)
    public float smoothSpeed = 5f; // Takip etme yumuşaklığı
    public Vector3 offset; // Kameranın oyuncuya göre mesafesi ve açısı

    void Start()
    {
        // Eğer offset başta atanmadıysa, kameranın andaki pozisyon farkını baz alalım
        if (offset == Vector3.zero && target != null)
        {
            offset = transform.position - target.position;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Kameranın gitmesi gereken hedef pozisyon
        Vector3 desiredPosition = target.position + offset;
        
        // Yumuşak bir geçişle (Lerp) kamerayı hedefe taşıyoruz
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}