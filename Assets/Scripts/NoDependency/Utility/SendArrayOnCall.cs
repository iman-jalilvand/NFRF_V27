using UnityEngine;
using System.Collections;

public class SendArrayOnCall : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("callSend")]
	public string Incoming;
    [UnityEngine.Serialization.FormerlySerializedAs("methodName")]
	public string Outgoing;
    [UnityEngine.Serialization.FormerlySerializedAs("onSend")]
	public Behaviour SendTo;

    public Parameter[] Parameters;

    private object[] parameters
    {
        get
        {
            object[] a = new object[Parameters.Length];
            for(int i = 0, max = Parameters.Length; i < max; ++i)
            {
                object o = null;
                Parameter p = Parameters[i];
                switch(p.type)
                {
                    case Parameter.ParameterType.Float:
                        o = p.floatValue;
                        break;
                    case Parameter.ParameterType.Integer:
                        o = p.intValue;
                        break;
                    case Parameter.ParameterType.String:
                        o = p.stringValue;
                        break;
                    case Parameter.ParameterType.SelfGameObject:
                        o = cachedGameObject;
                        break;
                    case Parameter.ParameterType.SelfTransform:
                        o = cachedTransform;
                        break;
                }
                a[i] = o;
            }

            return a;
        }
    }


    void Awake()
    {
        CacheMethod(Incoming, Send);
    }

    private void Send(object o)
    {
        switch (SendTo)
        {
            case Behaviour.Self:
                Call(Outgoing, cachedGameObject, parameters);
                break;
            case Behaviour.All:
                Call(Outgoing, typeof(Base), parameters);
                break;
        }
    }


    public enum Behaviour
    {
        Self,
        All
    }

    [System.Serializable]
    public struct Parameter
    {
        public ParameterType type;
        public string stringValue;
        public int intValue;
        public float floatValue;
        //public GameObject gameObjectValue;
        //public Transform transformValue;

        public enum ParameterType
        {
            String,
            Integer,
            Float,
            SelfGameObject,
            SelfTransform,
            //OtherGameObject,
            //OtherTransform,
            //OtherMonoBehaviour
        }
    }


}
