using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour
{
    [SerializeField] 
    private Transform[] puzzles;

    [SerializeField]
    private GameObject winText;
    [SerializeField]
    private GameObject startPanel;

    public static bool youWin;

    void Start()
    {
        Cursor.visible = false;
        StartCoroutine(StartGame());
        winText.SetActive(false);
        youWin = false;
    }

    void Update()
    {

        if (puzzles[0].rotation.z == 0 &&
           puzzles[1].rotation.z == 0 &&
           puzzles[2].rotation.z == 0 &&
           puzzles[3].rotation.z == 0)
        {
            print("WIN || ПОБЕДА");
            youWin = true;
            winText.SetActive(true);
        }

        //puzzles[4].rotation.z == 0 &&
        //puzzles[5].rotation.z == 0 &&
        //puzzles[6].rotation.z == 0 &&
        //puzzles[7].rotation.z == 0)

    }

    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4);
        startPanel.SetActive(false);
    }
}
