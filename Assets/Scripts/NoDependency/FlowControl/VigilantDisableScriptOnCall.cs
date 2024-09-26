using UnityEngine;
using System.Collections;

public class VigilantDisableScriptOnCall : Base {
	public string Incoming;
	public MonoBehaviour Script;

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Script.enabled = false;
		});
		base.OnEnable();
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
