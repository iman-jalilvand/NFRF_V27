using UnityEngine;
using System.Collections;

public class VigilantLookAtTransformOnUpdate : Base {

    public string CallSetTransform;
    public string CallSetUpDirection;
    public Transform TargetTransform;
    public Vector3 UpDirection = Vector3.up;

    // Use this for initialization
    void Awake() {
        base.OnEnable();
        CacheMethod(CallSetTransform,SetTransform);
        CacheMethod(CallSetUpDirection, SetUpDirection);
    }
    void OnDestroy()
    {
        base.OnDisable();
    }
    protected override void OnDisable(){    }
    protected override void OnEnable(){    }
    void SetUpDirection(object o)
    {
        if (o is Vector3)
        {
            UpDirection = (Vector3)o;
        }
    }
    void SetTransform(object o)
    {
        if(o is Transform)
        {
            TargetTransform = (Transform)o;
        }
    }
	// Update is called once per frame
	void Update () {
        cachedTransform.rotation = Quaternion.LookRotation(TargetTransform.position - cachedTransform.position, UpDirection);
	}
}
