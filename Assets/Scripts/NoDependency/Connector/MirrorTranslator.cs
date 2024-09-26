using UnityEngine;
using System.Collections;

public class MirrorTranslator : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("msgIn")]
    public string Incoming;

    [UnityEngine.Serialization.FormerlySerializedAs("msgOut")]
    public string Outgoing;
    public string CallSetTarget;
    [UnityEngine.Serialization.FormerlySerializedAs("target")]
    public GameObject Target;
	private void Awake()
	{
        UpdateCachedFields();
        CacheMethod(Incoming, (o) =>
        {
            Call(Outgoing, Target, o);
        });
        CacheMethod(CallSetTarget, SetTarget);
    }
    void SetTarget(object o)
    {
        if(o is GameObject)
        {
            Target = (GameObject)o;
        }
    }
}
