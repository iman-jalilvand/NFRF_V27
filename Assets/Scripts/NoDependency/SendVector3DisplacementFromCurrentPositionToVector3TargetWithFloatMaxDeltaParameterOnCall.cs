using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendVector3DisplacementFromCurrentPositionToVector3TargetWithFloatMaxDeltaParameterOnCall : Base {

    public string CallSendMoveToResult;
    public string OutgoingMoveToResult;
    public string OutgoingAtDestination;
    public string CallSetCurrentVector, CallSetTargetVector;
    public bool UpdateCurrentOnMove;
    public Vector3 CurrentVector;
    public Vector3 TargetVector;
    // Use this for initialization
    Coroutine moveRoutine;
    void Start()
    {
        CacheMethod(CallSendMoveToResult, MoveTowards);
        CacheMethod(CallSetCurrentVector, SetCurrent);
        CacheMethod(CallSetTargetVector, SetTarget);
    }
    void SetCurrent(object o)
    {
        if (o is Vector3)
        {
            CurrentVector = (Vector3)o;
        }
    }
    void SetTarget(object o)
    {
        if (o is Vector3)
        {
            TargetVector = (Vector3)o;
        }
    }
    void MoveTowards(object o)
    {
        float f;
        if (o is float)
        {
            f = (float)o;
            MoveTowards(f);
        }
        else if (o is int)
        {
            f = (int)o;
            MoveTowards(f);
        }
        else if (float.TryParse(o.ToString(),out f))
        {
            MoveTowards(f);
        }

    }
    void MoveTowards(float f)
    {

        Vector3 NewVector = Vector3.MoveTowards(CurrentVector, TargetVector, f);
        Vector3 Delta = NewVector - CurrentVector;
        if (UpdateCurrentOnMove)
        {
            CurrentVector = NewVector;
        }
        Call(OutgoingMoveToResult, cachedGameObject, Delta);
        if (NewVector == TargetVector)
        {
            Call(OutgoingAtDestination, cachedGameObject, TargetVector);
        }
    }
}
