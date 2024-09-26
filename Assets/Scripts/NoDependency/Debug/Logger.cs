using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Logger : Base
{
    public string CallPrint;
    public string Format = "NAME received METHOD with PARAMETER At TIME";
    public Color LogColor = Color.cyan;

    private void Awake()
    {
        CacheMethod(CallPrint, Print);
    }

    private void Print(object o)
    {
        string value = Format;

        string presplit = value.Replace("PARENT", "¥");
        string[] tokens = presplit.Split('¥');
        string s;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        int pCount = 0;

        for (int i = 0, max = tokens.Length; i < max; ++i)
        {
            s = tokens[i];
            if (s.Length > 0)
            {
                if (pCount > 0)
                {
                    sb.Append(getParentXName(cachedTransform, pCount));
                    pCount = 0;
                }
                sb.Append(s);
            }
            ++pCount;
        }
        if (pCount > 1)
        {
            sb.Append(getParentXName(cachedTransform, pCount-1));
        }
        value = sb.ToString();

        value = value.Replace("NAME", cachedGameObject.name);
        value = value.Replace("METHOD", CallPrint);
        value = value.Replace("TIME", Time.realtimeSinceStartup.ToString());
        value = value.Replace("PARAMETER", o == null ? "null" : o.ToString());
        value = "<color=#" + ColorToHex(LogColor) + ">" + value + "</color>";
        value = value + '\n' + GetStack();
        Debug.Log(value);
    }

    private string getParentXName(Transform t, int i)
    {
        if (t == null)
        {
            return "";
        }
        string rootName = t.root.name;
        for (; i > 0; --i)
        {
            if (t != null)
            {
                t = t.parent;
            }
        }
        if (t == null)
        {
            return rootName;
        }
        return t.name;
    }
    // Note that Color32 and Color implictly convert to each other. You may pass a Color object to this method without first casting it.
    string ColorToHex(Color32 color)
    {
        string hex = color.r.ToString("X2") + color.g.ToString("X2") + color.b.ToString("X2") + color.a.ToString("X2");
        return hex;
    }

    Color HexToColor(string hex)
    {
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    private string GetStack()
    {
        string result = "";

        foreach (KeyValuePair<Type, object> pair in CallStack)
        {
            result += pair.Key + " : " + pair.Value + '\n';
        }

        return result;
    }

}
