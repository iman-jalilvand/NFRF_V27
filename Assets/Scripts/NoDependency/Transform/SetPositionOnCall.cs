using UnityEngine;
using System.Collections;

public class SetPositionOnCall : Base
{
	public string Incoming;

	public bool IsLocal = true;
	private Vector3 targetPosition;

	private void Awake()
	{
		CacheMethod(Incoming, (o) =>
		{
			if (o is GameObject)
			{
				o = ((GameObject)o).transform;
			}

            if (o is Transform)
            {
                if (IsLocal)
                {
                    targetPosition = ((Transform)o).localPosition;
                }
                else
                {
                    targetPosition = ((Transform)o).position;
                }
            }
            if(o is Vector3)
            {
				targetPosition = (Vector3) o;
            }
            SetPosition(targetPosition);
		});
	}

    private void SetPosition(Vector3 targetToMatch)
    {
        if (IsLocal)
        {
            cachedTransform.localPosition = targetPosition;
        }
        else
        {
            cachedTransform.position = targetPosition;
        }
    }
}
