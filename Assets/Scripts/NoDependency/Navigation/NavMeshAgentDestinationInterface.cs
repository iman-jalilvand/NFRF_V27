using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NavMeshAgentDestinationInterface : Base
{
    public UnityEngine.AI.NavMeshAgent Agent;
    public Transform CurrentDestination;
    public string CallSetDestination;
    public float DestinationReachedThreshold;


	/// <summary>
	/// If given destination is Vector3, will spawn this prefab and assign position.
	/// This can be used for visualization and such. 
	/// </summary>
	public GameObject DestinationMarkerPrefab;
    private Transform destinationMarker;
	private Transform DestinationMarker
	{
		get {
			if(destinationMarker == null) {
				destinationMarker = Instantiate(DestinationMarkerPrefab).transform;
			}
			return destinationMarker;
		}
	}

	private Coroutine routine;

    private void Awake()
    {
        CacheMethod(CallSetDestination, SetDestination);
    }

	private void OnDestroy()
	{
		if(destinationMarker != null) {
			Destroy(destinationMarker);
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
	}

	protected override void OnDisable()
	{
		base.OnDisable();
	}

	private void SetDestination(object o)
    {
        Transform trans = ExtractTransform(o);
		if(CurrentDestination != trans) {
			CurrentDestination = trans;

			if(routine != null) {
				StopCoroutine(routine);
			}
			routine = StartCoroutine(AgentUpdateRoutine(CurrentDestination));
		}
    }

	private IEnumerator AgentUpdateRoutine(Transform target)
	{
		while(cachedGameObject.activeInHierarchy)
		{
			Agent.destination = CurrentDestination != null ? CurrentDestination.position : cachedTransform.root.position;
			yield return null;
		}
	}

    private Transform ExtractTransform(object o)
    {
        Transform trans = null;

        if (o is Vector3)
        {
            NavMeshHit hit;
            bool validPosition = NavMesh.SamplePosition((Vector3)o, out hit, 5, NavMesh.AllAreas);
            if (validPosition)
            {
                DestinationMarker.position = hit.position;
                o = DestinationMarker;
            }
        }
		
        if (o is GameObject && (GameObject)o != null)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            trans = o as Transform;
        }
        return trans;
    }
}
