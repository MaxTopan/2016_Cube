using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ZControl : MonoBehaviour
{
    public Text text;
    // Update is called once per frame
    void Update()
    {
        if (Controls.keyboardZ)
        { text.text = "1 2 3 Keys"; }
        else
        { text.text = "Controller"; }
    }
}
