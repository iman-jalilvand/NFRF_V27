using UnityEngine;
using System.Collections;

public class SelfGateMirror : Base
{
    public bool open;
    public string incoming, outgoing;
    public string callCloseGate, callOpenGate;
    public string callSetTarget;

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(incoming, IncomingMethod);
        CacheMethod(callCloseGate, CloseGate);
        CacheMethod(callOpenGate, OpenGate);
        CacheMethod(callSetTarget, SetTarget);
    }

    private void CloseGate(object o)
    {
        open = false;
    }

    private void OpenGate(object o)
    {
        open = true;
    }

    private void IncomingMethod(object o)
    {
        if (open)
        {
            Call(outgoing, cachedGameObject, o);
        }
    }


    private void SetTarget(object o)
    {
        cachedGameObject = o as GameObject;
    }
}
