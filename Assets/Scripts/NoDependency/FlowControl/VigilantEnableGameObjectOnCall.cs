using UnityEngine;
using System.Collections;

public class VigilantEnableGameObjectOnCall : Base {
	public string Incoming;
	public GameObject Target;

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Target.SetActive(true);
		});
		
		base.OnEnable();
	}

	private void OnDestroy()
	{
		base.OnDisable();
	}

	protected override void OnDisable()
	{
		//
	}

	protected override void OnEnable()
	{
		//
	}
}
