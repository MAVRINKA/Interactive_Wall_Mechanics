using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Secundomer : MonoBehaviour
{
    public float timeValue = 0f;
    public TextMeshProUGUI timerText;

    private void Update()
    {
        if(GameManager.isGame)
        timeValue += Time.deltaTime;
        DisplayTime(timeValue);
    }

    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
