using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
    public GameObject optionsScreen;
    public GameObject creditsScreen;
    public GameObject mainScreen;
    public GameObject xy;
    public GameObject z;
    //ControlName xyCon, zCon;

    void Start()
    {
        //xyCon = xy.GetComponent<ControlName>();
        //zCon = z.GetComponent<ControlName>();
    }

    public void Select(string selector)
    {
        if (selector == "start") // load next scene
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        else if (selector == "options") // open options menu
        {
            optionsScreen.SetActive(true);
            mainScreen.SetActive(false);
        }
        else if (selector == "credits") // open credits screen
        {
            creditsScreen.SetActive(true);
            mainScreen.SetActive(false);
        }
        else if (selector == "exit") // close game
        {
            Application.Quit();
        }
        else if (selector == "back") // back to menu
        {
            mainScreen.SetActive(true);

            if (optionsScreen != null)
                if (optionsScreen.activeSelf)
                optionsScreen.SetActive(false);

            if (creditsScreen != null)
                if (creditsScreen.activeSelf)
                    creditsScreen.SetActive(false);
        }
        else if (selector == "xy") // toggle xy controls
        {
            Controls.grid = !Controls.grid;
        }
        else if (selector == "z") // toggle z controls
        {
            Controls.keyboardZ = !Controls.keyboardZ;
        }
        else if (selector == "menu")
        {
            Application.LoadLevel(Application.loadedLevel - 1);
        }
        else if (selector == "retry")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        else if (selector == "pause")
        {
            mainScreen.SetActive(!mainScreen.activeSelf); // toggle menu screen
        }
        else if (selector == "deleteSave")
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
