using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilantSetActiveSelfOnCall : Base {
	public string CallSetActive;
	public string CallEnable;
	public string CallDisable;

	private void Awake()
	{
		base.OnEnable();
		CacheMethod(CallSetActive, SetActive);
		CacheMethod(CallEnable, Enable);
		CacheMethod(CallDisable, Disable);
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

	private void SetActive(object o)
	{
		bool b;
		if(o is bool) {
			b = (bool) o;
			cachedGameObject.SetActive(b);
		} else if(bool.TryParse(o.ToString(), out b)) {
			cachedGameObject.SetActive(b);
		}
	}

	private void Enable(object o)
	{
		cachedGameObject.SetActive(true);
	}

	private void Disable(object o)
	{
		cachedGameObject.SetActive(false);
	}
}
