using UnityEngine;

public class VigilantSendDistanceBetweenOnCall : Base {
	public string CallCalculate;
	public string CallSetSourceA;
	public string CallSetSourceB;
	public string Outgoing;

	public Transform SourceA;
	public Transform SourceB;

	private void Awake()
	{
		base.OnEnable();

		CacheMethod(CallCalculate, Calculate);
		CacheMethod(CallSetSourceA, SetSourceA);
		CacheMethod(CallSetSourceB, SetSourceB);
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

	private void Calculate(object o)
	{
		if(SourceA == null || SourceB == null) {
			return ;
		}

		float distance = Vector3.Distance(SourceA.position, SourceB.position);
		Call(Outgoing, cachedGameObject, distance);
	}

	private void SetSourceA(object o)
	{
		SourceA = CastToTransform(o);
	}

	private void SetSourceB(object o)
	{
		SourceB = CastToTransform(o);
	}

	private Transform CastToTransform(object o)
	{
		Transform trans = null;
		if(o is GameObject) {
			trans = ((GameObject)o).transform;
		}

		if(o is Transform) {
			trans = (Transform) o;
		}
		
		return trans;
	}
}