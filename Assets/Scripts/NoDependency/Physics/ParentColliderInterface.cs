using UnityEngine;
using System.Collections;

public class ParentColliderInterface : Base {
	private Collider c;
	[UnityEngine.Serialization.FormerlySerializedAs("callEnable")]
	public string CallEnable;
	[UnityEngine.Serialization.FormerlySerializedAs("callDisable")]
	public string CallDisable;

	private void Awake()
	{
		c = cachedTransform.parent.GetComponentInParent<Collider>();
		CacheMethod(CallEnable, Enable);
		CacheMethod(CallDisable, Disable);
	}

	private void Enable(object o)
	{
		c.enabled = true;
	}

	private void Disable(object o)
	{
		c.enabled =false;
	}
}
