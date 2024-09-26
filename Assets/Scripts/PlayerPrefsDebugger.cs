using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsDebugger : MonoBehaviour
{
    public string key;
    public enum PrefType {
        Float, Int, String
    }

    public int IntValue;
    public float FloatValue;
    public string StringValue;

    private void Update()
    {
        FloatValue = PlayerPrefs.GetFloat(key);
        IntValue = PlayerPrefs.GetInt(key);
        StringValue = PlayerPrefs.GetString(key);
    }
}
