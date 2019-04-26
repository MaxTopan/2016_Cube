using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class XYControl : MonoBehaviour
{
    public Text text;
    // Update is called once per frame
    void Update()
    {
        if (Controls.grid)
        { text.text = "Numpad"; }
        else
        { text.text = "Arrows/Controller"; }
    }
}
