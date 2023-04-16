using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchLocation
{
    public int touchID;
    public GameObject circle;
    internal int touchId;

    public TouchLocation(int newTouchID, GameObject newCircles)
    {
        touchID = newTouchID;
        circle = newCircles;
    }
}
