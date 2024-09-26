using UnityEngine;
using System.Collections;

public class CallOnTimer : Base {
    public string Outgoing;
    public string CallSetDuration;
    public float Duration;
	public bool ResetOnDisable = false;
    public Behaviour SendTo;

    private float elapsed;
    void Awake()
    {
        CacheMethod(CallSetDuration, SetDuration);
    }

    private void Update()
    {
        elapsed += Time.deltaTime;
        while(elapsed > Duration)
        {
            elapsed -= Duration;
            switch(SendTo)
            {
                case Behaviour.All:
                    Call(Outgoing, typeof(Base));
                    break;
                case Behaviour.Self:
                    Call(Outgoing, cachedGameObject);
                    break;
            }
        }
    }

	protected override void OnDisable()
	{
		if(ResetOnDisable) {
			elapsed = 0;
		}
		base.OnDisable();
	}
    private void SetDuration(object o)
    {
        float f;
        if (o is float)
        {
            f = (float)o;
            Duration = f;
        }
        if (o is int)
        {
            f = (float)(int)o;
            Duration = f;
        }
        if (float.TryParse(o.ToString(),out f))
        {
            Duration = f;
        }
    }
	public enum Behaviour
    {
        Self,
        All
    }
}
