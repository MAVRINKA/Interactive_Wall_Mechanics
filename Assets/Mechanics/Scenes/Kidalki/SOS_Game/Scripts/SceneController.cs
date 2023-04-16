using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{

    public GameObject infoPanel;
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            FindObjectOfType<ObjectSpawnerControl>().gameObject.GetComponent<ObjectSpawnerControl>().enabled = true;
            FindObjectOfType<TimerControl>().gameObject.GetComponent<TimerControl>().enabled = true;
            infoPanel.SetActive(false);
            Camera.main.gameObject.GetComponent<AudioSource>().enabled = true;
        }
    }
}
