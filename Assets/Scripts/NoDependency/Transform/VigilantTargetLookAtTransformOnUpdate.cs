using UnityEngine;
using System.Collections;

public class VigilantTargetLookAtTransformOnUpdate : Base
{
    public string CallSetTarget;
    public string CallSetTargetTransform;
    public string CallSetUpDirection;
    public Transform Target;
    public Transform TargetTransform;
    public Vector3 UpDirection = Vector3.up;

    // Use this for initialization
    void Awake()
    {
        base.OnEnable();
        CacheMethod(CallSetTarget, SetTarget);
        CacheMethod(CallSetTargetTransform, SetTransform);
        CacheMethod(CallSetUpDirection, SetUpDirection);
    }
    void OnDestroy()
    {
        base.OnDisable();
    }
    protected override void OnDisable() { }
    protected override void OnEnable() { }
    void SetUpDirection(object o)
    {
        if (o is Vector3)
        {
            UpDirection = (Vector3)o;
        }
    }
    void SetTarget(object o)
    {
        if (o is GameObject)
        {
            Target = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Target = (Transform)o;
        }
    }
    void SetTransform(object o)
    {
        if(o is GameObject)
        {
            TargetTransform = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            TargetTransform = (Transform)o;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Target.rotation = Quaternion.LookRotation(TargetTransform.position - cachedTransform.position, UpDirection);
    }
}
