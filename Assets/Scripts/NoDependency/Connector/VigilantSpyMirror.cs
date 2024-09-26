using UnityEngine;

public class VigilentSpyMirror : Base {
	public GameObject From;
	public GameObject To;
	public string CallMirror;
    public string CallSetFrom;
	public string CallSetTo;

	protected override void OnEnable()
	{
		// vigilant
	}

	protected override void OnDisable()
	{
		// vigilant
	}

	private void Awake()
    {
		base.OnEnable();

        if (From == null)
        {
            From = cachedGameObject;
        }

		CacheMethod(CallMirror, (o)=> {
			if (From == To)
			{
				CallMirror = "SELF MIRRORRING";
				Debug.LogError("VigilentSpyMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(CallMirror, To, o);
			}
		}, From);	

		CacheMethod(CallSetTo, SetTo);
		CacheMethod(CallSetFrom, SetFrom);
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

    private void SetFrom(object o)
    {
        if (o is GameObject)
        {
			base.OnDisable();
            From = (GameObject)o;
			Awake();
			base.OnEnable();
        }
    }

    private void SetTo(object o)
    {
        if (o is GameObject)
        {
            To = (GameObject)o;
        }
    }
}
