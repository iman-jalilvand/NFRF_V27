using UnityEngine;

public class MimicRotationLerpedBetweenTwoTransformsOnUpdate : Base {
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

	private void Update()
	{
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
		public Quaternion rotation;

		public Orientation(Transform source, Transform backup)
		{
			if(source != null) {
				rotation = source.rotation;
			} else {
				rotation = backup.rotation;
			}
		}

		public static Orientation Lerp(Orientation A, Orientation B, float rate)
		{
			Orientation result = new Orientation();

			Quaternion lerpedRotation = Quaternion.Slerp(A.rotation, B.rotation, rate);

			result.rotation = lerpedRotation;
			return result;
		}

		public override string ToString()
		{
			return "{ rotation:'" + rotation.ToString() + "'";
		}
	}
}
