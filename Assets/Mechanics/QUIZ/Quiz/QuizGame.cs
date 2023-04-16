using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class QuizGame : MonoBehaviour
{
    public QuestionList[] questions;
    public TextMeshProUGUI[] answersText;
    public Image img;

    public TextMeshProUGUI qText;
    public GameObject headPanel;
    public GameObject endGamePanel;
    public Button[] answerBttns = new Button[4];

    public TextMeshProUGUI TFText;
    public GameObject checkQuestionImg;

    private int score = 0;
    private int numberQuestion;

    public TextMeshProUGUI infoTxt;
    public TextMeshProUGUI scoreTxt;

    private AudioSource _audio;
    [Header("Audio")]
    public AudioClip win;
    public AudioClip gameover;


    List<object> qList;
    QuestionList crntQ;

    int randQ;
    bool defaultColor = false, trueColor = false, falseColor = false;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        //OnClickPlay();
        // arFaceManager = GameObject.Find("AR Session Origin").gameObject.GetComponent<ARFaceManager>();
        // arFaceManager.facePrefab = null;

        numberQuestion = questions.Length;
    }

    void Update()
    {
        if (defaultColor) headPanel.GetComponent<Image>().color = Color.Lerp(headPanel.GetComponent<Image>().color, new Color(231 / 255.0F, 78 / 255.0F, 62 / 255.0F), 8 * Time.deltaTime);
        if (trueColor) headPanel.GetComponent<Image>().color = Color.Lerp(headPanel.GetComponent<Image>().color, new Color(104 / 255.0F, 184 / 255.0F, 89 / 255.0F), 8 * Time.deltaTime);
        if (falseColor) headPanel.GetComponent<Image>().color = Color.Lerp(headPanel.GetComponent<Image>().color, new Color(192 / 255.0F, 57 / 255.0F, 43 / 255.0F), 8 * Time.deltaTime);

        IdentityTxtScore();
    }

    public void OnClickPlay()
    {
        qList = new List<object>(questions);
        StartCoroutine(QuestionGenerate());
        //if (!headPanel.GetComponent<Animator>().enabled) headPanel.GetComponent<Animator>().enabled = true;
        //else headPanel.GetComponent<Animator>().SetTrigger("In");
    }
    IEnumerator QuestionGenerate()
    {
        if (qList.Count > 0)
        {
            randQ = Random.Range(0, qList.Count);
            crntQ = qList[randQ] as QuestionList;
            qText.text = crntQ.question;

            List<string> answers = new List<string>(crntQ.answers);

            for (int i = 0; i < crntQ.answers.Length; i++)
            {
                int rand = Random.Range(0, answers.Count);
                answersText[i].text = answers[rand];
                answers.RemoveAt(rand);
            }

            //arFaceManager.enabled = false;
            yield return new WaitForEndOfFrame();
            //arFaceManager.enabled = true;
            Sprite image = crntQ.question_Img;
            img.sprite = image;
            //arFaceManager.facePrefab = faceID;
            //TFText.enabled = false;
            //checkQuestionImg.SetActive(false);
            //qText.gameObject.GetComponent<Animator>().SetTrigger("In");
            //StartCoroutine(animBttns());
        }
        else
        {
            print("Вы прошли игру");
            StartCoroutine(CompleteGame());
        }
    }

    IEnumerator CompleteGame()
    {
        //if(score <= numberQuestion / 2)
        //    infoTxt.text = "Стоит немного потренироваться!";
        //else
        //    infoTxt.text = infoTxt.text;

        yield return new WaitForEndOfFrame();
        endGamePanel.SetActive(true);
    }

    IEnumerator TrueOrFalse(bool check)
    {
        defaultColor = false;
        for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = false;
        yield return new WaitForSeconds(1);
        //for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].gameObject.GetComponent<Animator>().SetTrigger("Out");
        //qText.gameObject.GetComponent<Animator>().SetTrigger("Out");
        //if (!TFIcon.gameObject.activeSelf) TFIcon.gameObject.SetActive(true);
        //else TFIcon.gameObject.GetComponent<Animator>().SetTrigger("In");
        if (check)
        {
            trueColor = true;
            //QuestionComplete();
            score += 1;
            _audio.PlayOneShot(win);
            yield return new WaitForSeconds(3);
            //TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");
            qList.RemoveAt(randQ);
            StartCoroutine(QuestionGenerate());
            for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
            trueColor = false;
            defaultColor = true;
            yield break;
        }
        else
        {
            falseColor = true;
            //QuestionLoser();
            _audio.PlayOneShot(gameover);
            yield return new WaitForSeconds(3);
            qList.RemoveAt(randQ);
            StartCoroutine(QuestionGenerate());
            for (int i = 0; i < answerBttns.Length; i++) answerBttns[i].interactable = true;
            //TFIcon.gameObject.GetComponent<Animator>().SetTrigger("Out");
            //headPanel.GetComponent<Animator>().SetTrigger("Out");
            falseColor = false;
            defaultColor = true;
            yield break;
        }
    }
    public void AnswerBtns(int index)
    {
        if (answersText[index].text.ToString() == crntQ.answers[0]) StartCoroutine(TrueOrFalse(true));
        else StartCoroutine(TrueOrFalse(false));
    }

    public void IdentityTxtScore()
    {
        scoreTxt.text = score.ToString() + "/" + numberQuestion;
    }

    public void QuestionComplete()
    {
        checkQuestionImg.GetComponent<Animator>().SetTrigger("CheckQuestinos_trigger");
        TFText.enabled = true;
        TFText.color = Color.green;
        TFText.text = "Верно!";
    }

    public void QuestionLoser()
    {
        checkQuestionImg.GetComponent<Animator>().SetTrigger("CheckQuestinos_trigger");
        TFText.text = "Неверно!";
        TFText.color = Color.red;
        TFText.enabled = true;
    }
}
[System.Serializable]
public class QuestionList
{
    public string question;
    public string[] answers = new string[4];
    public Sprite question_Img;
}
