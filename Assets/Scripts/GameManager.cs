using UnityEngine;
using TMPro; // TextMeshPro kullanabilmek için şart
using UnityEngine.SceneManagement; // Sahneyi yeniden yüklemek için şart

public class GameManager : MonoBehaviour
{
    // Singleton yapısı (Her yerden kolay erişim için)
    public static GameManager instance;

    [Header("UI Elemanları")]
    public TextMeshProUGUI scoreText;      // Oyun içi sol üstteki altın sayacı
    public GameObject endPanel;           // Bitiş paneli
    public TextMeshProUGUI finishText;    // EndPanel içindeki "Kazandın / Tebrikler" yazısı
    public TextMeshProUGUI finalScoreText;// EndPanel içindeki süre yazısı (örn: Skor: X saniye)

    private int collectedGold = 0;
    private int totalGold = 5;
    private float timer = 0f;
    private bool isGameOver = false;

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Update()
    {
        // Oyun bitmediği sürece süreyi sayıyoruz
        if (!isGameOver)
        {
            timer += Time.deltaTime;
        }
    }

    public void AddGold()
    {
        if (isGameOver) return;

        collectedGold++;
        scoreText.text = "Altın: " + collectedGold;

        // 5 altın toplandıysa oyunu bitir
        if (collectedGold >= totalGold)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        isGameOver = true;
        endPanel.SetActive(true); 
        
        finishText.text = "Tebrikler, Kazandın!";
        finalScoreText.text = "Skor: " + timer.ToString("F2") + " saniye";

        // Karakteri bulup Victory animasyonunu tetikleyelim
        Animator playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
        if (playerAnimator != null)
        {
            playerAnimator.SetBool("isWin", true);
        }
    }

    // Butona bağlayacağımız yeniden başlama fonksiyonu
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}