using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddExplosionForceToParameterRigidbodyOnCall : Base
{

    public float Force;
    public Vector3 CenterOfExplosion;
    public bool CenterIsWorldCoordinate;
    public float Radius;
    public float UpwardsModifier;
    public ForceMode ForceModeUsed = ForceMode.Impulse;

    [SpaceAttribute(15)]
    public string CallAddExplosionForce;
    public string CallSetForce;
    public string CallSetCenter;
    public string CallSetRadius;
    public string CallSetUpwardModifier;

    private void Awake()
    {
        CacheMethod(CallAddExplosionForce, AddForce);
        CacheMethod(CallSetForce, SetForce);
        CacheMethod(CallSetCenter, SetCenter);
        CacheMethod(CallSetRadius, SetRadius);
        CacheMethod(CallSetUpwardModifier, SetUpwardModifier);
    }

    private void SetForce(object o)
    {
        if (o is int)
        {
            Force = (int)o;
        }
        if (o is float)
        {
            Force = (float)o;
        }
    }

    private void SetCenter(object o)
    {
        if (o is Vector3)
        {
            CenterOfExplosion = (Vector3)o;
        }
        if (o is GameObject)
        {
            CenterOfExplosion = ((GameObject)o).transform.position;
        }
        if (o is Transform)
        {
            CenterOfExplosion = ((Transform)o).position;
        }
    }

    private void SetRadius(object o)
    {
        if (o is int)
        {
            Radius = (int)o;
        }
        if (o is float)
        {
            Radius = (float)o;
        }
    }

    private void SetUpwardModifier(object o)
    {
        if (o is int)
        {
            UpwardsModifier = (int)o;
        }
        if (o is float)
        {
            UpwardsModifier = (float)o;
        }
    }

    private void AddForce(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).GetComponent<Rigidbody>();
        }

        if (o is Transform)
        {
            o = ((Transform)o).GetComponent<Rigidbody>();
        }

        Rigidbody rb = o as Rigidbody;

		if(rb == null) {
			return;
		}

        Vector3 Center;
        if (CenterIsWorldCoordinate)
        {
            Center = CenterOfExplosion;
        }
        else
        {
            Center = cachedTransform.position + CenterOfExplosion;
        }

        rb.AddExplosionForce(Force, Center, Radius, UpwardsModifier, ForceModeUsed);
    }
}
