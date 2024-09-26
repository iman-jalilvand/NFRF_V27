using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumericalFormatterProcesser : Base
{
    public string Incoming;
    public string Outgoing;
    public string Format;
    void Awake()
    {
        CacheMethod(Incoming, (o) =>
        {
            float f;
            float.TryParse(o.ToString(), out f);
            string str = string.Format("{0" + Format + "}", f);

            Call(Outgoing, cachedGameObject, str);
        });
    }
}