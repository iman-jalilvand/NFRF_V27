using UnityEngine;
using System.Collections;

public class MoveTargetTowardsVector3ParameterOnCall : Base
{
	public string CallMove;
	public string CallAtDestination;
    public string CallSetTarget;
    public string CallSetDelta;
	public float Delta;
    public Transform Target;
    bool isMoving = false;
    // Use this for initialization
    Coroutine moveRoutine;
    void Start()
    {
        CacheMethod(CallMove, MoveTowards);
        CacheMethod(CallSetDelta, SetSpeed);
        CacheMethod(CallSetTarget, SetTarget);
    }
    void MoveTowards(object o)
    {
        if (o is Vector3)
        {
            Target.position = Vector3.MoveTowards(Target.position,(Vector3)o,Delta);
        }
        else if (o is GameObject)
        {
            Target.position = Vector3.MoveTowards(Target.position, ((GameObject)o).transform.position, Delta);
        }
        else if (o is Transform)
        {
            Target.position = Vector3.MoveTowards(Target.position, ((Transform)o).position, Delta * Time.deltaTime);
        }
    }
    void SetTarget(object o)
    {
        if (o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        else if (o is Transform)
        {
            Target = ((Transform)o);
        }
        else if (o is Component)
        {
            Target = ((Component)o).transform;
        }
    }
    void SetSpeed(object o)
    {
        float f;
        if(o is float)
        {
            f = (float)o;
            Delta = f;
        }
        else if(float.TryParse(o.ToString(),out f))
        {
            Delta = f;
        }
    }
}
