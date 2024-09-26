using UnityEngine;
public class SpyToOriginMirror : Base
{
	public GameObject From;
	public string CallMirror;
	public string CallSetFrom;
	private void Awake()
	{
		CacheMethod(CallSetFrom, SetFrom);
		CacheMethod(CallMirror, (o) =>
		{
			GameObject To = cachedOriginGameObject;
			if (From == To)
			{
				CallMirror = "SELF MIRRORRING";
				Debug.LogError("VigilantSpyToSelfMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(CallMirror, To, o);
			}
		}, From);
	}
    

	private void SetFrom(object o)
	{
		if (o is GameObject)
		{
			From = (GameObject)o;

			base.OnDisable();
			Awake();
			base.OnEnable();
		}
	}
}
