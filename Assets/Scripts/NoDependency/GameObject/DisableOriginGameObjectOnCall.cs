using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOriginGameObjectOnCall : Base {
	public string CallDisable;
	private void Awake()
	{
		CacheMethod(CallDisable, (o)=> {
			cachedOriginGameObject.SetActive(false);
		});
	}
}
