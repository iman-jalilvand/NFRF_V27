using UnityEngine;
using System.Collections;

public class ChildTransformInterface : Base {

    public string CallDisableAllChildren;
    public string CallEnableChildAtIndex;
    public string CallDisableChildAtIndex;

	public string OnChildIndexOutOfRange;

    public string AlternativeDisableMessage;
	public string AlternativeEnableMessage;
    public bool SendDisableMessageInstead = false;
	public bool SendEnableMessageInstead = false;

    public bool OverflowIndex = true;

    private void Awake()
    {
        CacheMethod(CallDisableAllChildren, DisableAllChildren);
        CacheMethod(CallEnableChildAtIndex, EnableChildAtIndex);
        CacheMethod(CallDisableChildAtIndex, DisableChildAtIndex);
    }

    private void DisableAllChildren(object o)
    {
        foreach(Transform child in cachedTransform)
        {
			SetActiveGameObject(child.gameObject, SendDisableMessageInstead, false, AlternativeDisableMessage);
        }
    }

    private void EnableChildAtIndex(object o)
    {
        GameObject child = GetChildAtIndex(o);
		SetActiveGameObject(child, SendEnableMessageInstead, true, AlternativeEnableMessage);
    }

    private void DisableChildAtIndex(object o)
    {
        GameObject child = GetChildAtIndex(o);
		SetActiveGameObject(child, SendDisableMessageInstead, false, AlternativeDisableMessage);
    }

	private void SetActiveGameObject(GameObject go, bool messageInstead, bool active, string alternativeMessage)
	{
		if(go == null) {
			return;
		}

        if (messageInstead)
        {
            Call(alternativeMessage, go);
        } else if (go.activeInHierarchy != active)
        {
            go.SetActive(active);
        }
	}

    private GameObject GetChildAtIndex(object o)
    {
        int i;
        GameObject result = null;
        bool parsed = int.TryParse(o.ToString(), out i);

		if(!parsed) {
			return result;
		}

		if(i >= cachedTransform.childCount) {
			Call(OnChildIndexOutOfRange, cachedGameObject);
		}

        if(OverflowIndex)
        {
            i %= cachedTransform.childCount;
        }

        if (o != null && i < cachedTransform.childCount)
        {
            Transform child = cachedTransform.GetChild(i);
            result = child.gameObject;
        }

        return result;
    }
}
