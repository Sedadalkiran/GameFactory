using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private const string SCORE_KEY = "_score";
    [SerializeField]
    private Text _scoreText;
    private int score;



    private void Awake()
    {
        score = PlayerPrefs.GetInt(SCORE_KEY);
        UpdateScoreText();
        PlayerPrefs.DeleteKey("_score");

    }

    private void UpdateScoreText()
    {
        _scoreText.text = score.ToString("N");
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
        PlayerPrefs.SetInt(SCORE_KEY, score);
    }
}
