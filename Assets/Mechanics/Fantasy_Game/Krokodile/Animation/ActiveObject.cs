using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActiveObject : MonoBehaviour
{
    public UnityEvent activeObj_First;
    public UnityEvent activeObj_Second;

    public void ActiveObjFirst()
    {
        activeObj_First.Invoke(); 
    }

    public void ActiveObjSecond()
    {
        activeObj_Second.Invoke();
    }
}
