using UnityEngine;
using System.Collections;

public class SelfMoveTowardsOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("MoveKey")]
	public string CallMove;
    [UnityEngine.Serialization.FormerlySerializedAs("MoveEnd")]
	public string CallMoveEnd;
    public string CancelKey;
    [UnityEngine.Serialization.FormerlySerializedAs("speed")]
	public float Speed;
    private Vector3 target;
    bool isMoving = false;
    // Use this for initialization
    Coroutine moveRoutine;
    void Start()
    {
        CacheMethod(CallMove, MoveTowards);
        CacheMethod(CancelKey, CancelMove);
    }
    void MoveTowards(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }

        if (o is Transform)
        {
            o = ((Transform)o).position;
        }
        if (o is Vector3)
        {
            target = (Vector3)o;
        }
    }
    void CancelMove(object o)
    {
        target = cachedTransform.position;
        Call(CallMoveEnd, cachedGameObject);
    }
    void Update()
    {
        Vector3 curPos = cachedTransform.position;
        curPos = Vector3.MoveTowards(curPos, target, Speed * Time.deltaTime);
        cachedTransform.position = curPos;
        if (curPos == target)
        {
            Call(CallMoveEnd, cachedGameObject);
        }
    }
}
