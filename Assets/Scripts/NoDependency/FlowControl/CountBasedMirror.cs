using UnityEngine;
using System.Collections;

public class CountBasedMirror : Base {
	private int Count;
	public string Incoming;
	public string Outgoing;

	public Range[] Checks;
	public bool ResetCountOnEnable = true;
	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Count++;
			Check(o);
		});
	}

	protected override void OnEnable()
	{
		Count = 0;
		base.OnEnable();
	}

	private void Check(object o)
	{
		if(!(o is float)) {
			return;
		}

		for(int i = 0, max = Checks.Length; i < max; ++i) {
			Range r = Checks[i];
			bool inRange = r.IsInRange(Count);
			if(inRange) {
				Call(Outgoing, r.Target, o);
			}
		}
	}
	
	[System.Serializable]
	public struct Range
	{
		public GameObject Target;
		public int Min;
		public int Max;
		public bool InclusiveMin;
		public bool InclusiveMax;

		public bool IsInRange(int val)
		{
			bool minFine, maxFine;
			minFine = InclusiveMin ? val >= Min : val > Min;
			maxFine = InclusiveMax ? val <= Max : val < Max;
			return minFine && maxFine;
		}
	}
}
