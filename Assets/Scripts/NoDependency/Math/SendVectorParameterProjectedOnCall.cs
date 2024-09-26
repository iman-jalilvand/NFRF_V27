using UnityEngine;
using System.Collections;

public class SendVectorParameterProjectedOnCall : Base
{

    public string Incoming;
    public string Outgoing;
    
    public Vector3 Normal;
    void Start()
    {
        CacheMethod(Incoming, Project);
    }
    void Project(object o)
    {
        if (o is Vector3)
        {
            Call(Outgoing, cachedGameObject, Vector3.Project((Vector3)o, Normal));
        }
    }
}
