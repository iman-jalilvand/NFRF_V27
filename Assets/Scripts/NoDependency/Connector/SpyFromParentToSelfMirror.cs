using UnityEngine;

public class SpyFromParentToSelfMirror : Base
{
    public string Incoming;

    private GameObject From
    {
        get
        {
            return cachedTransform == null || cachedTransform.parent == null ? null : cachedTransform.parent.gameObject;
        }
    }

    private GameObject To
    {
        get
        {
            return cachedGameObject;
        }
    }

    private void OnTransformParentChanged()
    {
        OnDisable();
		Awake();
        OnEnable();
    }

    private void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
			if (From == To)
			{
				Incoming = "SELF MIRRORRING";
				Debug.LogError("SpyFromParentToSelfMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(Incoming, To, o);
			}
        }, From);
    }
}
