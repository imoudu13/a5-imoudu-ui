using TMPro;
using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private TextMeshProUGUI scoreText;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void IncreaseScore()
    {
        score++;

        if (coinCounter == null)
        {
            Debug.LogError("coinCounter is NULL in GameManager!");
            return;
        }

        if (scoreText == null)
        {
            Debug.LogError("scoreText is NULL in GameManager!");
            return;
        }

        coinCounter.UpdateScore(score);
        scoreText.text = $"Score: {score}";
    }

}
