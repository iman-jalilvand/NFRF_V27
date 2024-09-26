using UnityEngine;
using System.Collections;

public class CallOnStopwatch : Base
{
	public string CallStartCounting;
	public string CallStopCounting;
	public string CallPauseCounting;
	public string CallRestart;
	public string CallSetDuration;
    public string Outgoing;
    public float Duration;
    public bool ResetOnDisable = false;
    public bool IgnoreTimeScale = true;
    public Behaviour SendTo;

    private bool running = false;
    private float elapsed;

    private void Awake()
    {
        CacheMethod(CallStartCounting, StartCounting);
        CacheMethod(CallStopCounting, StopCounting);
        CacheMethod(CallPauseCounting, PauseCounting);
        CacheMethod(CallRestart, Restart);
        CacheMethod(CallSetDuration, SetDuration);
    }

    private void Restart(object o)
    {
        elapsed = 0;
    }

    private void SetDuration(object o)
    {
		float f;
		if(o is float) {
            elapsed = 0;
            Duration = (float)o;
		} else if (float.TryParse(o.ToString(), out f))
        {
            elapsed = 0;
            Duration = f;
        }
    }

    private void Update()
    {
        if (!running)
        {
            return;
        }

        elapsed += IgnoreTimeScale ? Time.unscaledDeltaTime : Time.deltaTime;
        if (elapsed > Duration)
        {
            running = false;
            elapsed = 0;
            switch (SendTo)
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

    private void StartCounting(object o)
    {
        running = true;
    }

    private void StopCounting(object o)
    {
        running = false;
        elapsed = 0;
    }

    private void PauseCounting(object o)
    {
        running = false;
    }

    protected override void OnDisable()
    {
        if (ResetOnDisable)
        {
            elapsed = 0;
        }
        base.OnDisable();
    }

    public enum Behaviour
    {
        Self,
        All
    }
}
