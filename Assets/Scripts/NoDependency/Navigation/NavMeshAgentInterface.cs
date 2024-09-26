
using System.Collections;

public class NavMeshAgentInterface : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("agent")]
	public UnityEngine.AI.NavMeshAgent Agent;
	[UnityEngine.Serialization.FormerlySerializedAs("callStop")]
	public string CallStop;
	[UnityEngine.Serialization.FormerlySerializedAs("callResume")]
	public string CallResume;

	private void Awake()
	{
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
