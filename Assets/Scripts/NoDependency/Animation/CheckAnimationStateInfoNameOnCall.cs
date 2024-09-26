using UnityEngine;

public class CheckAnimationStateInfoNameOnCall : Base
{
    private string fullName;
    [HeaderAttribute("Variables")]
    public string LayerName;
    public string StateName;

    [SpaceAttribute(3)]
    [HeaderAttribute("Messages")]
    public string CallCheck;
    public string OnPass;
    public string OnFail;

    void Start()
    {
        CacheMethod(CallCheck, CheckName);
        fullName = LayerName + '.' + StateName;
    }


    void CheckName(object o)
    {
        if (o is AnimatorStateInfo)
        {
            if (((AnimatorStateInfo)o).IsName(fullName))
            {
                Call(OnPass, cachedGameObject, o);
            }
            else
            {
                Call(OnFail, cachedGameObject, o);
            }
        }
    }
}
