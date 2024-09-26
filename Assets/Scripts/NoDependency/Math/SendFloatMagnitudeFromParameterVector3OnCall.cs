using UnityEngine;
using System.Collections;

public class SendFloatMagnitudeFromParameterVector3OnCall : Base {
	public string Incoming;
	public string Outgoing;

	private void Awake()
	{
		CacheMethod(Incoming, Convert);
	}
	
	private void Convert(object o)
	{
		if(!(o is Vector3)) {
			return;
		}
		Vector3 vec = (Vector3) o;
		float mag = vec.magnitude;
		Call(Outgoing, cachedGameObject, mag);
	}
}
