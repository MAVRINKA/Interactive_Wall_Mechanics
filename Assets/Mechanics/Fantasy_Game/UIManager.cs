using UnityEngine;
using DG.Tweening;
public class UIManager : MonoBehaviour
{

    [SerializeField]
    private
    RectTransform _mainMenu, _instructionPanel;

    public void Start()
    {
        _mainMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void GoInstriction()
    {

        _mainMenu.DOAnchorPos(new Vector2(0, 1190), 0.5f);
        _instructionPanel.DOAnchorPos(new Vector2(0, 0), 0.5f);
        //AudioManager.Instance.PlaySound2D("SelectLevel");

    }

    public void BackMainMenu()
    {

        _mainMenu.DOAnchorPos(new Vector2(0, 0), 0.5f);
        _instructionPanel.DOAnchorPos(new Vector2(0, -1200), 0.5f);
        //AudioManager.Instance.PlaySound2D("SelectLevel");

    }

}
