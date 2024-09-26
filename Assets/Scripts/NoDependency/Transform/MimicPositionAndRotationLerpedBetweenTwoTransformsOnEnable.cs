using UnityEngine;
using System.Collections;

public class MimicPositionAndRotationLerpedBetweenTwoTransformsOnEnable : Base {
	public Transform SourceA;
	public Transform SourceB;
	public float Rate;
	public string CallSetSourceA;
	public string CallSetSourceB;
	public string CallSetRate;

	private Orientation OrientationA
	{
		get {
			return new Orientation(SourceA, cachedTransform);
		}
	}

	private Orientation OrientationB
	{
		get {
			return new Orientation(SourceB, cachedTransform);
		}
	}

	private Orientation Lerped
	{
		get {
			return Orientation.Lerp(OrientationA, OrientationB, Rate);
		}
	}


	private void Awake()
	{
		UpdateCachedFields();
		CacheMethod(CallSetSourceA, SetSourceA);
		CacheMethod(CallSetSourceB, SetSourceB);
		CacheMethod(CallSetRate, SetRate);
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		cachedTransform.position = Lerped.position;
		cachedTransform.rotation = Lerped.rotation;
	}

	private void SetSourceA(object o) 
	{
		Transform trans = CastToTransform(o);
		SourceA = trans;
	}

	private void SetSourceB(object o) 
	{
		Transform trans = CastToTransform(o);
		SourceB = trans;
	}

	private void SetRate(object o)
	{
		if(o == null) {
			return;
		}

		float rate = Rate;
		float.TryParse(o.ToString(), out rate);
		Rate = rate;
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

	private struct Orientation
	{
		public Vector3 position;
		public Quaternion rotation;

		public Orientation(Transform source, Transform backup)
		{
			if(source != null) {
				position = source.position;
				rotation = source.rotation;
			} else {
				position = backup.position;
				rotation = backup.rotation;
			}
		}

		public static Orientation Lerp(Orientation A, Orientation B, float rate)
		{
			Orientation result = new Orientation();

			Vector3 lerpedPosition = Vector3.Lerp(A.position, B.position, rate);
			Quaternion lerpedRotation = Quaternion.Slerp(A.rotation, B.rotation, rate);

			result.position = lerpedPosition;
			result.rotation = lerpedRotation;
			return result;
		}

		public override string ToString()
		{
			return "{ position: '" + position.ToString() + "', rotation:'" + rotation.ToString() + "'";
		}
	}
}
