using UnityEngine;

public class Gift : MonoBehaviour
{
    [SerializeField] private bool isVictoryScore = false; // ≈сли true, добавл€ет очки к победному счету

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        if (isVictoryScore)
        {
            var scoreManager = FindObjectOfType<ScoreManagerForVictoryScreen>();
            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }
        }
        else
        {
            var scoreManager = FindObjectOfType<ScoreManagerForGameoverScreen>();
            if (scoreManager != null)
            {
                scoreManager.AddScore();
            }
        }

        Destroy(gameObject);
    }
}