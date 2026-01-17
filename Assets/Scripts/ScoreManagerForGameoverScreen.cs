using UnityEngine;
using TMPro;

public class ScoreManagerForGameoverScreen: MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public void AddScore()
    {
        score += 1;
        scoreText.text = "" + score;
    }
}