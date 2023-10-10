using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] TextMeshProUGUI scoreText;

    void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    public void UpdateScoreUI(int _score)
    {
        scoreText.text = _score.ToString();
    }
}
