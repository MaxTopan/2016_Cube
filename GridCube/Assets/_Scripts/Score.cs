using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour
{
    public Timer timer;
    Text text;
    int score = 0;
    private bool called;

    void Start()
    {
        text = GetComponent<Text>();
        text.text = "0";
    }

    void Update()
    {
        if (Controls.gameOver && !called)
        {
            UpdateHiScore(score);
            called = true;
        }
    }

    public void AddScore()
    {
        score += 1;
        text.text = score.ToString();
        CheckDifficulty();
    }

    void CheckDifficulty()
    {
        switch (score)
        {
            case 5:
                timer.ChangeDifficulty(9.0f, 1.0f);
                break;

            case 10:
                timer.ChangeDifficulty(8.0f, 1.0f);
                break;

            case 15:
                timer.ChangeDifficulty(7.0f, 0.8f);
                break;

            case 20:
                timer.ChangeDifficulty(5.0f, 0.7f);
                break;

            case 23:
                timer.ChangeDifficulty(4.0f, 0.6f);
                break;

            case 25:
                timer.ChangeDifficulty(3.0f, 0.5f);
                break;

            case 30:
                timer.ChangeDifficulty(2.0f, 0.4f);
                break;
        }
    }

    void UpdateHiScore(int newScore)
    {
        int oldScore = PlayerPrefs.GetInt("highscore", 0);
        if (newScore > oldScore)
            PlayerPrefs.SetInt("highscore", newScore);
    }
}