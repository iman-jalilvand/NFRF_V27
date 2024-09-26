using UnityEngine;

public class VigilantMirror : Base {
	public string Incoming;
	public string CallSetTarget;
	public GameObject Target;

	private void SetTarget(object o) {
		Target = o as GameObject;
	}

	private void Awake()
	{
		base.OnEnable();

		CacheMethod(CallSetTarget, SetTarget);
		CacheMethod(Incoming, (o) =>
		{
			if(Target == null) {
				return;
			}
			Call(Incoming, Target, o);
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