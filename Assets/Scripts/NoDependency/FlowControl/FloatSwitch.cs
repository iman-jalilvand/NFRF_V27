using UnityEngine;
using System.Collections;

public class FloatSwitch : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("checks")]
	public Range[] Checks;
	
	private void Awake()
	{
		CacheMethod(Incoming, Check);
	}

	private void Check(object o)
	{
		if(!(o is float)) {
			return;
		}

		float f = (float) o;
		for(int i = 0, max = Checks.Length; i < max; ++i) {
			Range r = Checks[i];
			bool inRange = r.IsInRange(f);
			if(inRange) {
				Call(r.Content, cachedGameObject);
			} else {
				Call(r.FailureCall, cachedGameObject);
			}
		}
	}

	[System.Serializable]
	public struct Range
	{
		public string Content;
		public string FailureCall;
		public float Min, Max;
		public bool InclusiveMin, InclusiveMax;

		public bool IsInRange(float val)
		{
			bool minFine, maxFine;
			minFine = InclusiveMin ? val >= Min : val > Min;
			maxFine = InclusiveMax ? val <= Max : val < Max;
			return minFine && maxFine;
		}
	}
}
