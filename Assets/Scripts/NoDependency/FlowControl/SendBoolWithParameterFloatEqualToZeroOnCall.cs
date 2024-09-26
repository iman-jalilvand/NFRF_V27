using UnityEngine;
using System.Collections;

public class SendBoolWithParameterFloatEqualToZeroOnCall : Base {
    public string Incoming, Outgoing;
    public bool Invert;
    void Awake()
    {
        CacheMethod(Incoming, SendParameter);
    }
    void SendParameter(object o)
    {
        float f;
		if(o is float) {
			f = (float)o;
            bool output = Invert ? f == 0 : f != 0;
            Call(Outgoing,cachedGameObject,output);
		} else if (float.TryParse(o.ToString(),out f))
        {
            bool output = Invert ? f == 0 : f != 0;
            Call(Outgoing,cachedGameObject,output);
        }
    }
}
