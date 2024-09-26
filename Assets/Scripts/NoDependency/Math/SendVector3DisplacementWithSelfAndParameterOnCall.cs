using UnityEngine;
using System.Collections;

public class SendVector3DisplacementWithSelfAndParameterOnCall : Base {


    public enum DisplacementDirection
    {
        ToParameter,
        ToSelf,
    }
    public string Incoming, Outgoing;
    public DisplacementDirection Direction;
    // Use this for initialization
    void Awake ()
    {
        CacheMethod(Incoming, SendDisplacement);
	}

    void SendDisplacement(object o)
    {
        Transform trans = null;
        if (o is Transform)
        {
            trans = (Transform)o;
        }
        else if (o is GameObject)
        {
            trans = ((GameObject)o).transform;
        }
        if (Direction == DisplacementDirection.ToParameter)
        {
            if (trans != null)
            {
                Vector3 displacement = trans.position - cachedTransform.position;
                Call(Outgoing, cachedGameObject, displacement);
            }
        }
        else if (trans != null)
        {
            Vector3 displacement = cachedTransform.position - trans.position;
            Call(Outgoing, cachedGameObject, displacement);
        }
    }
}
