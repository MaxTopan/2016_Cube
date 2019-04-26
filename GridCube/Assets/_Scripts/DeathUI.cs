using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathUI : MonoBehaviour
{
    public GameObject deathPanel;
    private bool activated = false;
    // public Text finalScore;

    // Update is called once per frame
    void Update()
    {
        if (Controls.gameOver && !activated)
        {
            activated = true;
            StartCoroutine(DeathScreen());
        }
    }

    public IEnumerator DeathScreen()
    {
        yield return new WaitForSeconds(1);
        deathPanel.SetActive(true);
    }
}