using TMPro;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;

    private bool isSettingsMenuActive;

    public bool IsSettingsMenuActive => isSettingsMenuActive;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        // the game starts with the settings menu disabled
        DisableSettingsMenu();
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

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void ToggleSettingsMenu()
    {
        if (isSettingsMenuActive) DisableSettingsMenu();
        else EnableSettingsMenu();
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isSettingsMenuActive = true;
    }

    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isSettingsMenuActive = false;
    }

}
