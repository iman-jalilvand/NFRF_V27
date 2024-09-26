using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ReplyNavigationDistanceOnCall : Base {
	public string CallSendNavigationDistance;
	public string CallSetSourceA;
	public string CallSetSourceB;
	public string Outgoing;
	public GameObject SourceA;
	public GameObject SourceB;

	private void Awake()
	{
		CacheMethod(CallSendNavigationDistance, SendNavigationDistance);
		CacheMethod(CallSetSourceA, SetSourceA);
		CacheMethod(CallSetSourceB, SetSourceB);
	}

	private void SetSourceA(object o)
	{
		if(o is GameObject) {
			SourceA = o as GameObject;
		}
	}

	private void SetSourceB(object o)
	{
		if(o is GameObject) {
			SourceB = o as GameObject;
		}
	}

	private void SendNavigationDistance(object o)
	{
		if(SourceA == null || SourceB == null) {
			return;
		}
		
		float distance = 0;
		bool validPath = true;
		Vector3 start = SourceA.transform.position, end = SourceB.transform.position;
		UnityEngine.AI.NavMeshHit hit;
		float sampleDistanceCap = 3;
		if(validPath && UnityEngine.AI.NavMesh.SamplePosition(start, out hit, sampleDistanceCap, UnityEngine.AI.NavMesh.AllAreas)) {
			start = hit.position;
		} else {
			validPath = false;
		}

		if(validPath && UnityEngine.AI.NavMesh.SamplePosition(end, out hit, sampleDistanceCap, UnityEngine.AI.NavMesh.AllAreas)) {
			end = hit.position;
		} else {
			validPath = false;
		}
		
		UnityEngine.AI.NavMeshPath path =  new UnityEngine.AI.NavMeshPath();
		if(validPath && UnityEngine.AI.NavMesh.CalculatePath(start, end, UnityEngine.AI.NavMesh.AllAreas, path)) {
			Vector3[] wayPoints = path.corners;
			distance += Vector3.Distance(start, wayPoints[0]);
			distance += Vector3.Distance(end, wayPoints[wayPoints.Length - 1]);

			for(int i = 0, max = wayPoints.Length; i + 1 < max; ++i) {
				distance += Vector3.Distance(wayPoints[i], wayPoints[i + 1]);
			}
		} else {
			validPath = false;
		}



		if(!validPath) {
			distance = float.NaN;
		}
		Reply(distance);
	}

	
	
	private void Reply(float distance)
	{
		KeyValuePair<Type, object> pair = CallStack.Peek();
		if(pair.Key.IsSubclassOf(typeof(Base)) || pair.Equals(typeof(Base))) {
			ReplyToBase((Base) pair.Value, distance);
		} else if(pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour))) {
			ReplyToMonoBehaviour((MonoBehaviour) pair.Value, distance);
		} else if(pair.Key.IsSubclassOf(typeof(MonoBehaviour)) || pair.Equals(typeof(MonoBehaviour))) {
			ReplyToGameObject((GameObject) pair.Value, distance);
		}
	}

	private void ReplyToBase(Base b, float distance)
	{
		GameObject cgo = GetCachedGameObject(b);
		Call(Outgoing, cgo, distance);
	}

	private void ReplyToGameObject(GameObject go, float distance)
	{
		Call(Outgoing, go, distance);
	}

	private void ReplyToMonoBehaviour(MonoBehaviour mono, float distance)
	{
		Call(Outgoing, mono.gameObject, distance);
	}
}
