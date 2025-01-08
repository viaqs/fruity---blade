using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    public static float remainingTime = 120;

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
        else if (remainingTime < 0)
        {
            remainingTime = 0;
            FindObjectOfType<UiManager>().EndGame();
        }

        int min = Mathf.FloorToInt(remainingTime / 60);
        int sec = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }

}
