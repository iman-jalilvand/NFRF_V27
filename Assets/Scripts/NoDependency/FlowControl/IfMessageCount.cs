using UnityEngine;
using System.Collections.Generic;

public class IfMessageCount : Base {
	public string[] Incomings;
	public ComplexCondition[] OutgoingLogics;

	public string CallResetCount;


	private Dictionary<string, int> MessageCount = new Dictionary<string, int>();

	private void Awake()
	{
		ResetCount(null);

		CacheMethod(CallResetCount, ResetCount);

		for(int i = 0, max = Incomings.Length; i < max; ++i) {
			string incoming = Incomings[i];
			CacheMethod(incoming, (o)=> {
				MessageCount[incoming] += 1;
				OutLogic();
			});
		}
	
	}

	private void OutLogic()
	{
		for(int i = 0, max = OutgoingLogics.Length; i < max; ++i) {
			ComplexCondition cc = OutgoingLogics[i];
			if(cc.IsValid(MessageCount)) {
				Call(cc.outgoing, cachedGameObject);
			}
		}
	}

	private void ResetCount(object o)
	{
		for(int i = 0, max = Incomings.Length; i < max; ++i) {
			MessageCount[Incomings[i]] = 0;
		}
	}

	[System.Serializable]
	public struct ComplexCondition
	{
		public string outgoing;
		public Condition[] conditions;

		public bool IsValid(Dictionary<string, int> Incomings)
		{
			bool isValid = true;
			bool initialized = false;
			for(int i = 0, max = conditions.Length; i < max && isValid; ++i) {
				initialized = true;
				isValid = conditions[i].IsValid(Incomings);
			}

			return isValid && initialized;
		}
	}

	[System.Serializable]
	public struct Condition
	{
		public string incoming;
		public int Value;
		public Check Range;

		public bool IsValid(Dictionary<string, int> Incomings)
		{
			return IsValid(Incomings[incoming]);
		}

		private bool IsValid(int count)
		{
			switch(Range)
			{
				case Check.Equals:
					return count == Value;
				case Check.NotEquals:
					return count != Value;
				case Check.Greater:
					return count > Value;
				case Check.Lesser:
					return count < Value;
				case Check.EGreater:
					return count >= Value;
				case Check.ELesser:
					return count <= Value;
				default:
					return false;
			}
		}
	}

	public enum Check
	{
		Equals,
		NotEquals,
		Greater,
		Lesser,
		EGreater,
		ELesser
	}
}
