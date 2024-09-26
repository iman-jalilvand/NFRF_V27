using UnityEngine;
using System.Collections;

public class SendTaggedObjectsOnCall : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Output;
	[UnityEngine.Serialization.FormerlySerializedAs("tagToSearch")]
	public string TagToSearch;
	[UnityEngine.Serialization.FormerlySerializedAs("callSendTaggedObjects")]
	public string CallSendTaggedObjects;

	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public SendTo Target;

	private void Awake()
	{
		CacheMethod(CallSendTaggedObjects, SendTaggedObjects);
	}

	private void SendTaggedObjects(object o)
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag(TagToSearch);
		switch(Target) {
			case SendTo.All:
				Call(Output, typeof(Base), objects);
				break;
			case SendTo.Self:
				Call(Output, cachedGameObject, objects);
				break;
		}
	}

	public enum SendTo
	{
		Self, 
		All
	}
}
