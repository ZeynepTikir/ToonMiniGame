using UnityEngine;

public class Gold : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // GameManager'a altının toplandığını haber veriyoruz
            if (GameManager.instance != null)
            {
                GameManager.instance.AddGold();
            }

            Destroy(gameObject);
        }
    }
}