using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isGame;

    private void Start()
    {
        isGame = true;
    }

    public void endGame()
    {
        isGame = false;
    }
}
