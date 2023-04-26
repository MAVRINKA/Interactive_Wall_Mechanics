using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchWallBox : MonoBehaviour
{

    private void OnMouseEnter()
    {
        transform.Rotate(0f, 0f, 90f);
    }

}
