using UnityEngine;

public class TimeScaleInterface : Base {
    [UnityEngine.Serialization.FormerlySerializedAs("callSetTimeScale")]
	public string Incoming;

    private void Awake()
    {
        CacheMethod(Incoming, SetTimeScale);
    }

    private void SetTimeScale(object o)
    {
        float result;
        if(float.TryParse(o.ToString(), out result))
        { 
            Time.timeScale = result;
        }
    }
}
