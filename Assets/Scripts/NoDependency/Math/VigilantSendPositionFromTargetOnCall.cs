using UnityEngine;
using System.Collections;

public class VigilantSendPositionFromTargetOnCall : Base {
	public string CallSendPosition;
	public string CallSetTarget;
	public string Outgoing;

	public Transform Target;

	private void Awake()
	{
		base.OnEnable();
		CacheMethod(CallSendPosition, SendPosition);
		CacheMethod(CallSetTarget, SetTarget);
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

	private void SendPosition(object o)
	{
		if(Target != null) {
			Call(Outgoing, cachedGameObject, Target.position);
		}
	}

	private void SetTarget(object o)
	{
		Target = ExtractTransform(o);
	}

	private Transform ExtractTransform(object o)
	{
		Transform go;
		if(o is GameObject) {
			o = ((GameObject)o).transform;
		}
		go = o as Transform;
		return go;
	}
}
