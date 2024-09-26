using UnityEngine;
using System.Collections;

public class AnimationCurveInterface : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("curve")]
	public AnimationCurve Curve;
	public float At;

	public string CallSetAt;
	public string CallEvaluate;
	public string CallGetValueAt;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(CallSetAt, SetAt);
		CacheMethod(CallEvaluate, Evaluate);
		CacheMethod(CallGetValueAt, GetValueAt);
	}

	private void SetAt(object o)
	{
		float f;

		if(o is float) {
			At = (float)o;
		} else if(o != null && float.TryParse(o.ToString(), out f))
		{
			At = f;
		}
	}

	private void Evaluate(object o)
	{
		float f = Curve.Evaluate(At);
		Call(Outgoing, cachedGameObject, f);
	}

	private void GetValueAt(object o)
	{
		SetAt(o);
		Evaluate(o);
	}
}
