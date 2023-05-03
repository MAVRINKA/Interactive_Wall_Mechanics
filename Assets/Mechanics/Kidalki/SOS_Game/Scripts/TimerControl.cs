using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerControl : MonoBehaviour
{
    public float timeValue = 90f;
    public TextMeshProUGUI timerText;

    public GameObject losePanel;
    public GameObject winPanel;

    private void Update()
    {
         if(timeValue > 0 && ObjectSpawnerControl.spawnAllowed == true)
        {
            timeValue -= Time.deltaTime;
        }

         else if(timeValue <= 0)
        {
            winPanel.SetActive(true);
            ObjectSpawnerControl.spawnAllowed = false;
        }

         else
        {
            DisplayTime(timeValue);
        }

        DisplayTime(timeValue);
    }

    public void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

