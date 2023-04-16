using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brackets : MonoBehaviour
{
	//[SerializeField] private GameObject startButton;
	//[SerializeField] private GameObject insructionButton;
	//[SerializeField] private GameObject selectLevelButton;
	//[SerializeField] private GameObject exitButton;

	public GameObject[] tooth;


	//[SerializeField] private Transform startContainer;

	//[SerializeField] private CanvasGroup title;

	private const float INITIAL_DELAY = 1f;
	private const float DELAY_BETWEEN_BUTTONS = 0.3f;

	private List<GameObject> buttons = new List<GameObject>();
	private List<Sequence> animationSequences = new List<Sequence>();

	private void Awake()
	{

		for (int i = 0; i < tooth.Length; i++)
		{
			buttons.Add(tooth[i]);
		}

		AnimateButtons();
	}

	private void Start()
	{

		//AudioManager.Instance.PlaySound2D("MenuBtn");

	}


	private void OnDestroy()
	{
	}

	private void AnimateButtons()
	{
		for (int i = 0; i < tooth.Length; i++)
		{
			buttons[i].transform.localScale = Vector3.zero;
			AnimateButton(i, INITIAL_DELAY + DELAY_BETWEEN_BUTTONS * i);
		}

	}

	private void AnimateButton(int index, float delay)
	{
		if (animationSequences.Count <= index)
		{
			animationSequences.Add(DOTween.Sequence());

		}
		else
		{
			if (animationSequences[index].IsPlaying())
			{
				animationSequences[index].Kill(true);
			}

		}

		var seq = animationSequences[index];
		var button = buttons[index];

		seq.Append(button.transform.DOScale(Vector3.one, 0.3f));
		seq.Append(button.transform.DOPunchScale(new Vector3(1.2f, 1.2f, 1f), 0.6f).SetEase(Ease.OutCirc));
		seq.PrependInterval(delay);

		//GetComponentInChildren<Animator>().enabled = true;
	}
}
