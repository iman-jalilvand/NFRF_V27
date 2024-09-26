using UnityEngine;
using System.Collections;

public class CallEnumerableMethodOnCall : Base {
    public string[] Outgoings;
    public int OutgoingIndexToCall = 0;

    public Behaviour SendTo;
    public string CallCallEnumerableMethod;

    /// <summary>
    /// If set to false, must manually change the MethodIndexToCall
    /// </summary>
    public bool autoIterate = true;

    private void Awake()
    {
        CacheMethod(CallCallEnumerableMethod, CallEnumerableMethod);
    }

    private void CallEnumerableMethod(object o)
    {
        if(Outgoings.Length == 0)
        {
            return;
        }

        switch (SendTo)
        {
            case Behaviour.Self:
                Call(Outgoings[OutgoingIndexToCall], cachedGameObject);
                break;
            case Behaviour.All:
                Call(Outgoings[OutgoingIndexToCall], typeof(Base));
                break;
        }

        if(autoIterate)
        {
            OutgoingIndexToCall += 1;
            OutgoingIndexToCall %= Outgoings.Length;
        }
    }

    public enum Behaviour
    {
        Self, 
        All
    }
}
