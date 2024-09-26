using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
public class LookAtMainCameraOnUpdate : Base
{
	public bool LockY;

    protected override void OnEnable()
    {
        base.OnEnable();
		Update();
    }

    void Update()
	{
		if (LockY)
		{
			Vector3 cameraPos = Camera.main.transform.position;
			cameraPos.y = CachedTransform.position.y;
			cachedTransform.LookAt(cameraPos, Vector3.up);
		}
		else
		{
			cachedTransform.LookAt(Camera.main.transform, Vector3.up);
		}
	}
}
