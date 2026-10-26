using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 6f; // Karakterin hareket hızı
    private CharacterController controller;
    private Animator animator; // Animator bileşeni için referans

    void Start()
    {
        // Sahnedeki CharacterController bileşenini alıyoruz
        controller = GetComponent<CharacterController>();
        
        // Karakterin üzerindeki veya alt objesindeki Animator'ı buluyoruz
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        // Klavye girdilerini alıyoruz (W, A, S, D veya Ok Tuşları)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Hareket vektörünü oluşturuyoruz (Y ekseni dikey/yerçekimi için 0)
        Vector3 move = new Vector3(moveX, 0f, moveZ);

        // Karakteri hareket ettiriyoruz
        controller.Move(move * speed * Time.deltaTime);

        // Karakterin hareket ettiği yöne doğru dönmesini sağlar (Görsel olarak güzel durur)
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }

        // --- ANİMATÖR KONTROLÜ ---
        // Eğer animator bileşeni atanmışsa hareket durumuna göre isRunning'i güncelle
        if (animator != null)
        {
            if (move != Vector3.zero)
            {
                animator.SetBool("isRunning", true);
            }
            else
            {
                animator.SetBool("isRunning", false);
            }
        }
    }
}