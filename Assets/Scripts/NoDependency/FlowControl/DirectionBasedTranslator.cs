using UnityEngine;
using System.Collections;

//Converts vector3 to direction corresponding to SteamVR controller

public class DirectionBasedTranslator : Base {
    public string Incoming;
	public string Outgoing;

    public float magnitudeCheckThreshold = 1f;
    public string OnSwingLeftDetected;
    public string OnSwingRightDetected;
    public string OnSwingUpDetected;
    public string OnSwingDownDetected;
    public string OnSwingForwardDetected;

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(Incoming, Convert);
    }

    public float directionCheckThreshold = 1f; //tuned value
    private void Convert(object o)
    {
        if (!(o is Vector3))
        {
            return;
        }
        Vector3 vec = (Vector3)o;
        float mag = vec.magnitude;

        if (mag > magnitudeCheckThreshold)
        {
            //Debug.Log(vec + " " + mag + " " + magnitudeCheckThreshold + " " + Mathf.Sqrt(magnitudeCheckThreshold));
            if (vec.y < -directionCheckThreshold)
            {
                SwingDown(mag);
            }
            else if (vec.y > directionCheckThreshold)
            {
                SwingUp(mag);
            }
            else if (vec.x > directionCheckThreshold)
            {
                SwingLeft(mag);
            }
            else if (vec.x < -directionCheckThreshold)
            {
                SwingForward(mag);
            }
            else if (vec.z > directionCheckThreshold)
            {
                SwingRight(mag);
            }
        }
    }

    private void SwingLeft(float parameter)
    {
        Call(OnSwingLeftDetected, cachedGameObject, parameter);
    }

    private void SwingRight(float parameter)
    {
        Call(OnSwingRightDetected, cachedGameObject, parameter);
    }

    private void SwingUp(float parameter)
    {
        Call(OnSwingUpDetected, cachedGameObject, parameter);
    }

    private void SwingDown(float parameter)
    {
        Call(OnSwingDownDetected, cachedGameObject, parameter);
    }

    private void SwingForward(float parameter)
    {
        Call(OnSwingForwardDetected, cachedGameObject, parameter);
    }
}
