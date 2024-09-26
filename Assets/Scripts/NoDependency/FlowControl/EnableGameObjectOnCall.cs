using UnityEngine;
using System.Collections;

public class EnableGameObjectOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public GameObject Target;
    [UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
    public string CallSetTarget;
	[UnityEngine.Serialization.FormerlySerializedAs("callEnable")]
	public string CallEnable;

	private void Awake()
    {
        CacheMethod(CallEnable, Enable);
        CacheMethod(CallSetTarget, SetTarget);
    }
    private void SetTarget(object o)
    {
        if(o is GameObject)
        {
            Target = (GameObject)o;
        }
    }
	private void Enable(object o)
	{
		if (Target != null) {
			Target.SetActive (true);
		}
	}
}
