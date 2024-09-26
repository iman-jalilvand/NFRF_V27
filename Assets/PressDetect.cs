using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressDetect : Base
{
	public string Starting, Ending;
	public GameObject Target;
	private void Awake()
	{
		CacheMethod(Starting, (o) =>
		{
			if(o.ToString() == "Select")
				Target.SetActive(true);
		}); 
		
		CacheMethod(Ending, (o) =>
		{
			if (o.ToString() == "Select")
				Target.SetActive(false);
		});

	}
}
