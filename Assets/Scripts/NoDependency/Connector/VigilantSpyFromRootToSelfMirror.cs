using UnityEngine;
using System.Collections;

public class VigilantSpyFromRootToSelfMirror : Base
{

	[Tooltip("This Spy is self upding to look for the new root when reenabled or when receiving this message")]
	public string CallMirror;

	private GameObject From;
	private GameObject To;

	protected override void OnEnable()
	{
		// empty for vigillance
	}

	protected override void OnDisable()
	{
		// empty for vigillance
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

	private void Awake()
	{
		base.OnEnable();
		if (From == null)
		{
			From = cachedGameObject;
		}
	}

	private void OnTransformParentChanged()
	{
		base.OnDisable();
		UpdateCachedFields();
		Initialize();
		base.OnEnable();
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
				Debug.LogError("VigilantSpyFromRootToSelfMirror on " + cachedOriginGameObject.name + " is mirrorring itself");
			}
			else
			{
				Call(CallMirror, To, o);
			}
		}, From);
	}
}
