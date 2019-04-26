using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    Menu menu;

    void Start()
    {
        menu = GetComponent<Menu>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ToggleUI();
        }
    }

    public void ToggleUI()
    {
        paused = !paused;
        if (paused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
        menu.Select("pause");
    }
}
