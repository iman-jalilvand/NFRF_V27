using UnityEngine;
using System.Collections;

public class FindRandomTaggedObjectOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	public string Outgoing;
	public string CallFindRandomObject;
	[UnityEngine.Serialization.FormerlySerializedAs("defaultTag")]
	public string DefaultTag = "Untagged";
	[UnityEngine.Serialization.FormerlySerializedAs("useDefaultNameIfParameterNotValid")]
	public bool UseDefaultNameIfParameterNotValid = true;
	[UnityEngine.Serialization.FormerlySerializedAs("alwaysUseDefaultName")]
	public bool AlwaysUseDefaultName = false;

	private void Awake()
	{
		CacheMethod(CallFindRandomObject, FindRandomObject);
	}

	private void FindRandomObject(object o)
	{
		string targetName = AlwaysUseDefaultName ? DefaultTag : o as string;

		if(string.IsNullOrEmpty(targetName)) {
			if(UseDefaultNameIfParameterNotValid) {
				targetName = DefaultTag;
			}
			else {
				return;
			}
		}
		GameObject[] candidates = GameObject.FindGameObjectsWithTag(DefaultTag);
		GameObject target = candidates[Random.Range(0, candidates.Length)];

		Call(Outgoing, cachedGameObject, target);
	}
}
