using TMPro;
using UnityEngine;

public class UIGAmeOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
    }
    void Start()
    {
        scoreText.text = "Loser. Your score is: \n" + scoreKeeper.Score;
    }

}
