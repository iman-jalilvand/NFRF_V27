using UnityEngine;

public class NavMeshInterface : Base
{

    public string UpdateMessage;

    [SpaceAttribute(3)]
    [Header("Incomming Messages")]
    [UnityEngine.Serialization.FormerlySerializedAs("IncomingCornersMessage")]
	public string CallGetCornerCount;
    [UnityEngine.Serialization.FormerlySerializedAs("IncomingNavigationDistanceMessage")]
	public string CallGetNavigationDistance;
    [UnityEngine.Serialization.FormerlySerializedAs("IncomingPathCompletenessStatusMessage")]
	public string CallGetPathCompleteness;

    [SpaceAttribute(3)]
    [Header("Outgoing Messages")]
    public string OutgoingCornersMessage;
    public string OutgoingNavigationDistanceMessage;
    public string OutgoingPathCompletenessStatusMessage;

    [SpaceAttribute(3)]
    [Header("Path Destination and source")]
    public string CallSetSource;
    public string CallSetDestination;

    [SpaceAttribute(3)]
    public Transform Source;
    public Transform Destination;

    private bool navigationDistanceUpdated;
    private float navigationDistance;
    private UnityEngine.AI.NavMeshPath lastCalculatedPath;

    void Awake()
    {
        CacheMethod(UpdateMessage, CalculateNaveMesh);
        CacheMethod(CallGetCornerCount, GetCornerCount);
        CacheMethod(CallGetNavigationDistance, GetNavigationDistance);
        CacheMethod(CallGetPathCompleteness, GetPathCompleteness);
        CacheMethod(CallSetSource, SetSource);
        CacheMethod(CallSetDestination, SetDestination);
    }

    private void SetSource(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Source = o as Transform;
        }
    }

    private void SetDestination(object o)
    {
        if (o is GameObject)
        {
            o = ((GameObject)o).transform;
        }
        if (o is Transform)
        {
            Destination = o as Transform;
        }
    }

    private void GetCornerCount(object o)
    {
        if (lastCalculatedPath == null)
        {
            Call(OutgoingCornersMessage, cachedGameObject, -1);
        }
        else
        {
            Call(OutgoingCornersMessage, cachedGameObject, lastCalculatedPath.corners.Length);
        }
    }

    private void GetNavigationDistance(object o)
    {
        if (navigationDistanceUpdated == false)
        {
            navigationDistance = 0;
            if (lastCalculatedPath.status != UnityEngine.AI.NavMeshPathStatus.PathComplete)
            {
                CalculateNaveMesh(o);
            }
            if (lastCalculatedPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete)
            {
                Vector3[] corners = lastCalculatedPath.corners;
                for (int i = 0, max = corners.Length - 1; i < max; ++i)
                {
                    float distance = Vector3.Distance(corners[i], corners[i + 1]);
                    navigationDistance += distance;
                }
                //update the navigation distance updated so we dont have to do math until the next time this is updated
                navigationDistanceUpdated = true;
            }
        }

        Call(OutgoingNavigationDistanceMessage, cachedGameObject, navigationDistance);
    }

    private void GetPathCompleteness(object o)
    {
        if (lastCalculatedPath == null)
        {
            Call(OutgoingPathCompletenessStatusMessage, cachedGameObject, false);
        }
        else
        {
            Call(OutgoingPathCompletenessStatusMessage, cachedGameObject, lastCalculatedPath.status == UnityEngine.AI.NavMeshPathStatus.PathComplete);
        }
    }

    private void CalculateNaveMesh(object o)
    {
        if (lastCalculatedPath == null)
        {
            lastCalculatedPath = new UnityEngine.AI.NavMeshPath();
        }
        if (Source != null && Destination != null)
        {
            Vector3 source = Source.position;
            Vector3 dest = Destination.position;
            UnityEngine.AI.NavMesh.CalculatePath(source, dest, UnityEngine.AI.NavMesh.AllAreas, lastCalculatedPath);
        }
        else
        {
            lastCalculatedPath = new UnityEngine.AI.NavMeshPath();
        }
        navigationDistanceUpdated = false;
    }

}
