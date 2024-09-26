using UnityEngine;

public class SpyFromParentToOriginMirror : Base
{
    public string Incoming;

	private GameObject From;
	private GameObject To;

    private void Awake()
    {
        UpdateCachedFields();
        From = cachedTransform.parent.gameObject;
        To = cachedOriginGameObject;
        CacheMethod(Incoming, (o) =>
        {
			if (From == To)
			{
				Incoming = "SELF MIRRORRING";
				Debug.LogError("SpyFromParentToOriginMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(Incoming, To, o);
			}
        }, From);
    }

	private void OnTransformParentChanged()
	{
		OnDisable();
		Awake();
		OnEnable();
	}
}
