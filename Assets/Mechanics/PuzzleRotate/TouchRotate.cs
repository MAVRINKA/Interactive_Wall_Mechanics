using UnityEngine;
using System.Collections;

public class TouchRotate : MonoBehaviour
{

    private void OnMouseDown()
    {
        if(!GameControl.youWin)
        {
            StartCoroutine(RotatePuzzle());
        }

        //ПОВОРАЧИВАЕМ ПАЗЗЛ НА 90 градусов по оси Z 
           
                           //x,  y,   z   
    }

    IEnumerator RotatePuzzle()
    {
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        transform.Rotate(0f, 0f, 90f);
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
