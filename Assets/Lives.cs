using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
    public Timer timerScript; // Reference to your Timer script
    public Text livesText;
    private int lives = 3;

    void Update()
    {
        if (timerScript.timeValue <= 0 && lives > 0)
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString();
            if (lives > 0)
            {
                timerScript.timeValue = 240; // Reset the timer
            }
        }
    }
}
