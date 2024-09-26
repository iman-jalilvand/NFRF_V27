using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VigilantSetActiveOriginOnCall : Base {
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
			cachedOriginGameObject.SetActive(b);
		} else if(bool.TryParse(o.ToString(), out b)) {
			cachedOriginGameObject.SetActive(b);
		}
	}

	private void Enable(object o)
	{
		cachedOriginGameObject.SetActive(true);
	}

	private void Disable(object o)
	{
		cachedOriginGameObject.SetActive(false);
	}
}
