using UnityEngine;
using System.Collections;

public class SendNavMeshPositionFromPositionParameterOnCall : Base {
	public float MaxDistance;
	public string Incoming;
	public string OutgoingOnHit;
	public string OutgoingOnMiss;
	
	private void Awake()
	{
		CacheMethod(Incoming, Send);
	}

	private void Send(object o)
	{
		bool fail = true;
		if(o is Vector3) {
			Vector3 worldPosition = (Vector3)o;
			UnityEngine.AI.NavMeshHit hit;
			if(UnityEngine.AI.NavMesh.SamplePosition(worldPosition, out hit, MaxDistance, UnityEngine.AI.NavMesh.AllAreas)) {
				Vector3 navMeshPosition = hit.position;
				fail = false;
				Call(OutgoingOnHit, cachedGameObject, navMeshPosition);
			}
		}

		if(fail) {
			Call(OutgoingOnMiss, cachedGameObject);
		}
	}
}
