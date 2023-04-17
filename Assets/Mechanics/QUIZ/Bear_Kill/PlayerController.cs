using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject losePanel, winPanel;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            losePanel.SetActive(true);
        }
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
    }
}
