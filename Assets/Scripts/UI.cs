using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject gamePauseUI;
    [SerializeField] GameObject gameStartUI;

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
    }

    public void UpdateScoreUI(int _score) => scoreText.text = _score.ToString();

    public void GamePauseUI(bool _pause) => gamePauseUI.SetActive(_pause);

    public void GameStartUI(bool _gameStart) => gameStartUI.SetActive(_gameStart);
}
