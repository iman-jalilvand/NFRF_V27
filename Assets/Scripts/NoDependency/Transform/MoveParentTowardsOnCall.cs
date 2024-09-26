using UnityEngine;

public class MoveParentTowardsOnCall : Base
{
    public string CallMove;
    public string OutgoingOnAtDestination;
    public string CallStop;
    [UnityEngine.Serialization.FormerlySerializedAs("speed")]
	public float Speed;
    private Vector3 target;
    bool isMoving = false;
    // Use this for initialization
    Coroutine moveRoutine;
    void Awake()
    {
        UpdateCachedFields();
        CacheMethod(CallMove, MoveTowards);
        CacheMethod(CallStop, CancelMove);
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
        target = cachedTransform.parent.position;
        Call(OutgoingOnAtDestination, cachedGameObject);
    }
    void Update()
    {
        Vector3 curPos = cachedTransform.parent.position;
        curPos = Vector3.MoveTowards(curPos, target, Speed * Time.deltaTime);
        cachedTransform.parent.position = curPos;
        if (curPos == target)
        {
            Call(OutgoingOnAtDestination, cachedGameObject);
        }
    }
}
