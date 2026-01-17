using TMPro;
using UnityEngine;

public class ScoreManagerForVictoryScreen : MonoBehaviour
{
    public int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public void AddScore()
    {
        score += 1;
        scoreText.text = "" + score;
    }
}