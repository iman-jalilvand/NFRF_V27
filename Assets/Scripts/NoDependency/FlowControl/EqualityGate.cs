using UnityEngine;
using System.Collections;

public class EqualityGate : Base
{

    public string Incoming;
    [UnityEngine.Serialization.FormerlySerializedAs("EqualOutgoing")]
    public string OutgoingEqual;
    [UnityEngine.Serialization.FormerlySerializedAs("UnEqualOutgoing")]
    public string OutgoingUnEqual;

    public string SetLHS;
    public string SetRHS;

    private object LHS;
    private object RHS;

    private void Awake()
    {
        CacheMethod(Incoming, CheckEquality);
        CacheMethod(SetLHS, (o) =>
        {
            LHS = o;
        });
        CacheMethod(SetRHS, (o) =>
        {
            RHS = o;
        });
    }

    private void CheckEquality(object o)
    {
        // yes i know that the last rhs != null is *technically* not necessarily
        // but sometimes when rhs is null lhs.euqls makes it match
        // *shurg*
        if ((RHS == null && LHS == null) || (LHS != null && LHS.Equals(RHS) && RHS != null))
        {
            Call(OutgoingEqual, cachedGameObject, o);
        }
        else
        {
            Call(OutgoingUnEqual, cachedGameObject, o);
        }
    }
}
