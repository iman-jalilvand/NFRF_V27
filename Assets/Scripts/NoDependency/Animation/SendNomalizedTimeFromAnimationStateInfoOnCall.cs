using UnityEngine;
using System.Collections;

public class SendNomalizedTimeFromAnimationStateInfoOnCall : Base
{

    [HeaderAttribute("Calls")]
    public string CallGetNormalizedTime;
    public string CallGetSendLoopAmount;
    public string CallGetProgress;

    [HeaderAttribute("Outputs")]
    [UnityEngine.Serialization.FormerlySerializedAs("OnGetNormalizedTime")]
	public string OutputOnGetNormalizedTime;
    [UnityEngine.Serialization.FormerlySerializedAs("OnGetSendLoopAmount")]
	public string OutputOnGetSendLoopAmount;
    [UnityEngine.Serialization.FormerlySerializedAs("OnGetProgress")]
	public string OutputOnGetProgress;

    void Start()
    {
        CacheMethod(CallGetNormalizedTime, GetNormalizedTime);
        CacheMethod(CallGetSendLoopAmount, GetSendLoopAmount);
        CacheMethod(CallGetProgress, GetProgress);
    }

    void GetNormalizedTime(object o)
    {
        if (o is AnimatorStateInfo)
        {
            float f = ((AnimatorStateInfo)o).normalizedTime;
            Call(OutputOnGetNormalizedTime, cachedGameObject, f);
        }
    }

    void GetSendLoopAmount(object o)
    {
        if (o is AnimatorStateInfo)
        {
            float f = ((AnimatorStateInfo)o).normalizedTime;
            Call(OutputOnGetSendLoopAmount, cachedGameObject, Mathf.Floor(f));
        }
    }

    void GetProgress(object o)
    {
        if (o is AnimatorStateInfo)
        {
            float f = ((AnimatorStateInfo)o).normalizedTime;
            Call(OutputOnGetProgress, cachedGameObject, f % 1);
        }
    }
}
