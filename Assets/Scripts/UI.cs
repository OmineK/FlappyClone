using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;

    [Header("InGame TextMesh info")]
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameOverCurrentScoreText;
    [SerializeField] TextMeshProUGUI gameOverBestScoreText;

    [Header("InGame panels info")]
    [SerializeField] GameObject gamePauseUI;
    [SerializeField] GameObject gameStartUI;
    [SerializeField] GameObject gameOverPanel;

    void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        gameOverPanel.SetActive(false);
    }

    public void PlayAgainButton()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void GoToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

    public void UpdateScoreUI(int _score) => scoreText.text = _score.ToString();

    public void GamePauseUI(bool _pause) => gamePauseUI.SetActive(_pause);

    public void GameStartUI(bool _gameStart) => gameStartUI.SetActive(_gameStart);

    public void GameOverUI(int _currentScore, int _bestScore)
    {
        gameOverPanel.SetActive(true);

        gameOverCurrentScoreText.text = "Current score: " + _currentScore;
        gameOverBestScoreText.text = "Best score: " + _bestScore;
    }
}
