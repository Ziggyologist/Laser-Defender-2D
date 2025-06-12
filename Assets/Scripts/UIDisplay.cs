using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;

    [Header("Score")]
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.Score.ToString("0000000000");
    }
}
