using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public float x, y, z;
    public GameObject krocodile; 
    
    //nextButton, replayButton,
    //historyTxt, levelSuccess, winPanel;

    //[SerializeField]
    //AudioSource _audio;


    private void Start()
    {
        //LeanTween.scale(krocodile, new Vector3(0.5f, 0.5f, 0.5f), 2f).setDelay(.5f).setEase(LeanTweenType.easeOutElastic).setOnComplete(EyesFlip);
        LeanTween.moveLocal(krocodile, new Vector3(0, 0, 0), .5f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(EyesFlip);

        //_audio.volume = 0.1f;
        // winPanel.SetActive(true);
        //LeanTween.moveLocal(levelSuccess, new Vector3(40f, 62f, 2f), .7f).setDelay(2f).setEase(LeanTweenType.easeInOutCubic);
        // LeanTween.scale(levelSuccess, new Vector3(0.25f, 0.25f, 0.25f), 2f).setDelay(1.7f).setEase(LeanTweenType.easeInOutCubic);
    }

    public void LevelComplete()
    {
    //    _audio.Play();
    //    LeanTween.moveLocal(backPanel, new Vector3(0f, 2.2f, 0f), 0.7f).setDelay(.5f).setEase(LeanTweenType.easeOutCirc);
    //    LeanTween.scale(replayButton, new Vector3(0.8f, 0.8f, 0.8f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
    //    LeanTween.scale(nextButton, new Vector3(0.8f, 0.8f, 0.8f), 2f).setDelay(1f).setEase(LeanTweenType.easeOutElastic);
    }

    public void EyesFlip()
    {
        LeanTween.scaleX(krocodile, -1f, .1f).setDelay(0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(EyesFlip);
    }


}
