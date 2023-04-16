using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SunDestroys : MonoBehaviour
{
    public int scoreSun = 0;
    public GameObject[] suns;
    public GameObject winGame;

    public UnityEvent winEvent;

    public void SunKills()
    {
        scoreSun++;
    }

    private void Update()
    {
        if(scoreSun >= suns.Length)
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        if(winEvent != null)
        winEvent.Invoke();
    }
}
