using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardActive : MonoBehaviour
{
    public GameObject[] cards;
    public int numbCard = 0;
    public float inTime;

    public void CardOn()
    {
        StartCoroutine(CardsActive());
    }

    public IEnumerator CardsActive()
    {
        yield return new WaitForSeconds(inTime);
        cards[numbCard].SetActive(true);
        numbCard++;
    }
}
