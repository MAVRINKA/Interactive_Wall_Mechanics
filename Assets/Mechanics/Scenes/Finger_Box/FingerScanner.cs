using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FingerScanner : MonoBehaviour
{

    public GameObject[] solution;

    private AudioSource audioSource;
    public AudioClip complete, error;

    [SerializeField] private TextMeshProUGUI _topPanelText;
    [SerializeField] private TextMeshProUGUI _bottomPanelText;

    [SerializeField] private GameObject[] guess;

    private enum ScanStatus { Idle, Scanning, Complete, Error };
    private ScanStatus scanStatus = ScanStatus.Idle;

    public void OnTouch(GameObject gO)
    {
        int finger = Input.touchCount - 1;
        guess[finger] = gO;
    }

    public void OnRelease(GameObject gO)
    {
        for(int i = 0; i < guess.Length; i++)
        {
            if(guess[i] == gO) { guess[i] = null; }
        }
    }

    private void Start()
    {
        _topPanelText.text = "Коснитесь блоков";
        guess = new GameObject[solution.Length];
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {

        int numFingers = Input.touchCount;

        switch (scanStatus)
        {
            case ScanStatus.Idle:
                _bottomPanelText.text = string.Format("{0} количество касаний", numFingers);
                if(numFingers == solution.Length)
                {
                    scanStatus = ScanStatus.Scanning;
                }
                break;

            case ScanStatus.Scanning:
                Debug.Log("Scanning");
                _topPanelText.text = "Сканируем";

                bool allCorrect = true;
                for(int i = 0; i < solution.Length; i++)
                {
                    if(!(guess[i] != null && guess[i].Equals(solution[i])))
                    {
                        allCorrect = false;
                    }
                }

                if(allCorrect)
                {
                    Debug.Log("Complete");
                    audioSource.clip = complete;
                    audioSource.Play();
                    _topPanelText.text = "Верно!";
                    scanStatus = ScanStatus.Complete;
                    //FindObjectOfType<RabbitUpDown>().UpRabbit();
                    //FindObjectOfType<RabbitUpDown>().ButtonsGameActive();
                }
                else
                {
                    Debug.Log("Error");
                    audioSource.clip = error;
                    audioSource.Play();
                    _topPanelText.text = "Неверно!";
                    scanStatus = ScanStatus.Error;
                }

                break;

            case ScanStatus.Complete:
                if(numFingers == 0)
                {
                    _topPanelText.text = "Коснитесь блоков";
                    scanStatus = ScanStatus.Idle;
                }

                break;

            case ScanStatus.Error:
                if(numFingers == 0)
                {
                    _topPanelText.text = "Коснитесь блоков";
                    scanStatus = ScanStatus.Idle;
                }
                break;
        }

    }


}
