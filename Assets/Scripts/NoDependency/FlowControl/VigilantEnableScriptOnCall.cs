using UnityEngine;
using System.Collections;

public class VigilantEnableScriptOnCall : Base {
	public string Incoming;
	public MonoBehaviour Script;

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Script.enabled = true;
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
