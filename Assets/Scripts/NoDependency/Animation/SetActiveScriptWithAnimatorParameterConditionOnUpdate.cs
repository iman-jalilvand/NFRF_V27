using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveScriptWithAnimatorParameterConditionOnUpdate : Base {
	public Condition IfCondition;
	public MonoBehaviour script;
	public Animator animator;
	public string FloatParameterName;
	public string CallManualValidation = "AnimatorIncrementFloatStunDuration";

	private void Awake()
	{
		CacheMethod(CallManualValidation, (o)=> {
			script.enabled = IsValid(animator.GetFloat(FloatParameterName));
		});
	}

	private void Update()
	{
		script.enabled = IsValid(animator.GetFloat(FloatParameterName));
	}

	public bool IsValid(float other) {
        bool result = true;
        result &= IfCondition.IsValid(other);

		return result;
	}

	[System.Serializable]
	public struct Condition
	{
		public float Value;
		public Check Range;

		public bool IsValid(float other)
		{
			switch(Range)
			{
				case Check.Equals:
					return other == Value;
				case Check.NotEquals:
					return other != Value;
				case Check.Greater:
					return other > Value;
				case Check.Lesser:
					return other < Value;
				case Check.EGreater:
					return other >= Value;
				case Check.ELesser:
					return other <= Value;
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
