using UnityEngine;
using System.Collections;

public class DeathShortcuts : MonoBehaviour
{
    public GameObject menuObj;
    Menu menu;

    void Start()
    {
        menu = menuObj.GetComponent<Menu>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            menu.Select("retry");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            menu.Select("menu");
        }
    }
}
