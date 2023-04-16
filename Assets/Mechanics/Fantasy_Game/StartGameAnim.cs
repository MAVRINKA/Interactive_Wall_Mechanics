using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameAnim : MonoBehaviour
{
    [SerializeField]
    GameObject PlayButton, BackPanel;

    [SerializeField]
    AudioSource _audio;

    private void Awake()
    {

        //PlayButton.transform.localScale = new Vector3(0f, 0f, 0f);
        BackPanel.transform.localScale = new Vector3(0f, 0f, 0f);
        StartTween();

    }

    private void Start()
    {
        _audio.volume = 0.1f;
        _audio.Play();
    }

    void StartTween()
    {
        LeanTween.scale(BackPanel, new Vector3(1f, 1f, 1f), 0.9f).setDelay(.3f).setEase(LeanTweenType.easeOutCirc);
        LeanTween.scale(PlayButton, new Vector3(1f, 1f, 1f), 0.7f).setDelay(.6f).setEase(LeanTweenType.easeOutCirc);
        //PlayButton.transform.DOScale(1.1f, 0.75f).SetLoops(-1, LoopType.Yoyo).Play();

    }
}
