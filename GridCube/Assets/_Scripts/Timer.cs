using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float maxTime = 10.0f;
    public GameObject bar;
    public GameObject difficultyNote;
    private float timeToAdd = 2.0f;
    private float timeLeft = 0;
    private bool called = false;

    void Start()
    {
        timeLeft = maxTime;
        Controls.gameOver = false;
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft >= maxTime)
                timeLeft = maxTime;
            ScaleBar();
        }
        else
        {
            GameOver();
        }
    }

    public void AddTime()
    {
        timeLeft += timeToAdd;
    }

    public void ChangeDifficulty(float cap, float bonus)
    {
        maxTime = cap;
        timeToAdd = bonus;

        Vector3 spawn = new Vector3(2.0f, 3.3f, 3.0f);
        Instantiate(difficultyNote, spawn, Quaternion.identity);
    }

    public void ScaleBar()
    {
        if (bar != null)
            bar.transform.localScale = new Vector3(timeLeft / maxTime, 1, 1);
    }

    void GameOver()
    {
        if (!called)
        {
            Destroy(bar.gameObject);
            Controls.gameOver = true;
            called = true;
        }
    }
}