using UnityEngine;


public class FBBIKElbowLimiter : MonoBehaviour
{
	public Transform LeftGoal;
	public Transform LeftAnchor;
	public float LeftAnchorLength;
	public Transform LeftElbow;

	public Transform RightGoal;
	public Transform RightAnchor;
	public float RightAnchorLength;
	public Transform RightElbow;
    
	void LateUpdate()
	{
		Vector3 diff = LeftGoal.position - LeftAnchor.position;
		if (diff.sqrMagnitude > (LeftAnchorLength * LeftAnchorLength))
		{
			Vector3 norm = diff.normalized;
			Vector3 offset = norm * LeftAnchorLength;
			LeftElbow.position = LeftAnchor.position + offset;
		}
		else
		{
			LeftElbow.position = LeftGoal.position;
		}

		diff = RightGoal.position - RightAnchor.position;
		if (diff.sqrMagnitude > (RightAnchorLength * RightAnchorLength))
		{
			Vector3 norm = diff.normalized;
			Vector3 offset = norm * RightAnchorLength;
			RightElbow.position = RightAnchor.position + offset;
		}
		else
		{
			RightElbow.position = RightGoal.position;
		}
	}

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawSphere(RightAnchor.position, RightAnchorLength);
        Gizmos.color = new Color(0, 1, 1, 0.25f);
        Gizmos.DrawSphere(LeftAnchor.position, LeftAnchorLength);

    }
#endif
}
