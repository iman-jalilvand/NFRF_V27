using UnityEngine;
using System.Collections.Generic;
using System;


public class GameObjectDictionary : Base
{
    public GameObject DonateObject;
    public string CallSendGameObject;
    public string Outgoing;
    public string OutgoingFailed;
    public ObjectType objectType;
    public outputType Output = outputType.GameObject;
    public enum outputType
    {
        GameObject,
        Transform
    }

    public string ShareID;
    public string CallSetShareID;

    // i think we need one more to tell whether each pos rot scale should be in local or not

    private static Dictionary<string, GameObject> objects = new Dictionary<string, GameObject>();
	private static event OnDonorChanged DonorChangeEvent;
	private delegate void OnDonorChanged(string ID);

    private void Awake()
    {
        UpdateCachedFields();
        CacheMethod(CallSetShareID, SetShareID);
        CacheMethod(CallSendGameObject, SendGameObject);
		DonorChangeEvent += Check;

        if (objectType == ObjectType.Donor)
        {
            DonorUpdate();
        }
    }

    void OnDestroy()
    {
		if(objectType == ObjectType.Donor) {
			objects.Remove(ShareID);
		}

		DonorChangeEvent -= Check;
    }

	private void Check(string ID)
	{
		if(ID == ShareID) {
			RecipientUpdate();
		}
	}

    void SendGameObject(object o)
    {
        RecipientUpdate();
    }
    private void DonorUpdate()
    {
        if (DonateObject)
        {
            objects[ShareID] = DonateObject;
			DonorChangeEvent(ShareID);
        }
    }

    private void RecipientUpdate()
    {
        if (objects.ContainsKey(ShareID))
        {
            switch (Output)
            {
                case outputType.GameObject:
                    Call(Outgoing, cachedGameObject, objects[ShareID]);
                    break;
                case outputType.Transform:
                    Call(Outgoing, cachedGameObject, objects[ShareID].transform);
                    break;
            }
        }
        else
        {
            Call(OutgoingFailed, cachedGameObject);
        }
    }

    private void SetShareID(object o)
    {
        ShareID = o.ToString();
    }

    public enum ObjectType
    {
        Donor,
        Recipient
    }
}

