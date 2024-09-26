using UnityEngine;

public class SpyMirror : Base
{
    public GameObject From;
    public GameObject To;
    public string CallMirror;
    public string CallSetFrom;
    public string CallSetTo;
	
    private void SetFrom(object o)
    {
		if(o is Transform) {
			o = ((Transform)o).gameObject;
		}

        if (o is GameObject)
        {
			From = o as GameObject;
			OnDisable();
			Awake();
			OnEnable();
        }
    }
    private void SetTo(object o)
    {
		if(o is Transform) {
			o = ((Transform)o).gameObject;
		}

        if (o is GameObject)
        {
            To = (GameObject)o;
        }
    }

    private void Awake()
    {
        if (From == null)
        {
            From = cachedGameObject;
        }

        CacheMethod(CallMirror, (o) =>
        {
			if (From == To)
			{
				CallMirror = "SELF MIRRORRING";
				Debug.LogError("SpyMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(CallMirror, To, o);
			}
        }, From);

        CacheMethod(CallSetTo, SetTo);
		CacheMethod(CallSetFrom, SetFrom);
    }
}
