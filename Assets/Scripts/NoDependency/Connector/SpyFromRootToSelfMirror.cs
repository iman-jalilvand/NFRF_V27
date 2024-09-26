using UnityEngine;

public class SpyFromRootToSelfMirror : Base
{
	public string CallMirror;

	private GameObject From;
	private GameObject To;

	private void Awake()
	{
		if (From == null)
		{
			From = cachedGameObject;
		}
		Initialize();
	}

	private void OnTransformParentChanged()
	{
		OnDisable();
		Initialize();
		OnEnable();
	}

	private void Initialize()
	{
		UpdateCachedFields();
		From = cachedTransform.root.gameObject;
		To = cachedGameObject;
		CacheMethod(CallMirror, (o) =>
		{
			if (From == To)
			{
				CallMirror = "SELF MIRRORRING";
				Debug.LogError("SpyFromRootToSelfMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(CallMirror, To, o);
			}
		}, From);
	}
}
