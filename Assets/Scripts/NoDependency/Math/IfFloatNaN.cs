using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfFloatNaN : Base {
	public string Incoming;
	public string OutgoingOnTrue;
	public string OutgoingOnFalse;

	private void Awake()
	{
		CacheMethod(Incoming, (o)=> {
			float f = float.NaN;
			if(o is float) {
				f = ((float) o);
			} else if(float.TryParse(o.ToString(), out f)) {
				//
			}

			bool isNaN = float.IsNaN(f);
			Call(isNaN ? OutgoingOnTrue : OutgoingOnFalse, cachedGameObject);
		});
	}
}
