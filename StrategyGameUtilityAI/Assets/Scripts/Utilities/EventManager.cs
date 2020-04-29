using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void EventAction();
    public static event EventAction OnAction;

    public void InvokeEvent(EventAction e)
    {

    }
}
