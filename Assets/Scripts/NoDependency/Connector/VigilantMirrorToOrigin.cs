using UnityEngine;
using System.Collections;

public class VigilantMirrorToOrigin : Base
{
    public string Incoming;

    private void Awake()
    {
		base.OnEnable();
        UpdateCachedFields();
        CacheMethod(Incoming, (o) =>
        {
            Call(Incoming, cachedOriginGameObject, o);
        });
    }

	private void OnDestroy()
	{
		base.OnDisable();
	}

	protected override void OnEnable()
	{
		//
	}

	protected override void OnDisable()
	{
		//
	}
}
