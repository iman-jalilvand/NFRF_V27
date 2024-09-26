using UnityEngine;
using System.Collections;

public class SendVectorParameterProjectedOnPlaneOnCall : Base
{

    public string Incoming;
    public string Outgoing;

    [UnityEngine.Serialization.FormerlySerializedAs("planeNormal")]
    public Vector3 PlaneNormal;
    void Start()
    {
        CacheMethod(Incoming, Project);
    }
    void Project(object o)
    {
        if (o is Vector3)
        {
            Call(Outgoing, cachedGameObject, Vector3.ProjectOnPlane((Vector3)o, PlaneNormal));
        }
    }
}
