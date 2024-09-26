	using UnityEngine;
using System.Collections;

public class SelfNavMeshAgentInterface : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("agent")]
	private UnityEngine.AI.NavMeshAgent Agent;
    [UnityEngine.Serialization.FormerlySerializedAs("callStop")]
	public string CallStop;
	[UnityEngine.Serialization.FormerlySerializedAs("callResume")]
	public string CallResume;

    private void Awake()
    {
        UpdateCachedFields();
        Agent = cachedGameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        CacheMethod(CallStop, Stop);
        CacheMethod(CallResume, Resume);
    }

    private void Stop(object o)
    {
        Agent.Stop();
    }

    private void Resume(object o)
    {
        Agent.Resume();
    }
}
