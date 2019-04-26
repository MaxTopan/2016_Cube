using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HighScore : MonoBehaviour
{
    Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {       
        text.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }
}
