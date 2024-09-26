using UnityEngine;
public class SpyToSelfMirror : Base
{
	public GameObject From;
	public string CallMirror;
	public string CallSetFrom;
	private void Awake()
	{
		CacheMethod(CallSetFrom, SetFrom);
		CacheMethod(CallMirror, (o) =>
		{
			GameObject To = cachedGameObject;
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
