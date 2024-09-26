using UnityEngine;
using System.Collections;

public class MirrorAdaptTranslator : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("incoming")]
	public string Incoming;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetTarget")]
	public string CallSetTarget;
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public GameObject Target;
	[UnityEngine.Serialization.FormerlySerializedAs("candidates")]
	public OutgoingCandidate[] Candidates;

	[UnityEngine.Serialization.FormerlySerializedAs("outgoing")]
	private string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			Call(Outgoing, Target, o);
		});

		CacheMethod(CallSetTarget, SetTarget);

		for(int i = 0, max = Candidates.Length; i < max; ++i) {
			OutgoingCandidate candidate = Candidates[i];
			string newOutgoing = candidate.Outgoing;
			CacheMethod(candidate.Incoming, (o)=> {
				Outgoing = newOutgoing;
			});
		}
	}

	private void SetTarget(object o)
	{
		GameObject go = o as GameObject;
		Target = go;
	}

	[System.Serializable]
	public struct OutgoingCandidate
	{
		public string Incoming;
		public string Outgoing;
	}
}
