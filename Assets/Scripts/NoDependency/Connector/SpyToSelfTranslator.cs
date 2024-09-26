using UnityEngine;
public class SpyToSelfTranslator : Base
{
	public GameObject From;
	public string Incoming,Outgoing;
	public string CallSetFrom;
	private void Awake()
	{
		CacheMethod(CallSetFrom, SetFrom);
		CacheMethod(Incoming, (o) =>
		{
			GameObject To = cachedGameObject;
			if (From == To)
			{
                Outgoing = "SELF MIRRORRING";
				Debug.LogError("VigilantSpyToSelfMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(Outgoing, To, o);
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
