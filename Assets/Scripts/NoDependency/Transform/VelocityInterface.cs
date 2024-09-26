using UnityEngine;
using System.Collections.Generic;

public class VelocityInterface : Base
{
    [UnityEngine.Serialization.FormerlySerializedAs("duration")]
    public float Duration = 1f;

    public Vector3 Velocity
    {
        get
        {
            Vector3 vel = Vector3.zero;
            foreach (Sample delta in deltas)
            {
                vel += delta.DeltaMovement;
            }
            return vel;
        }
    }

    public float SampleTotalDuration
    {
        get
        {
            float t = 0;
            foreach (Sample delta in deltas)
            {
                t += delta.DeltaTime;
            }

            return t;
        }
    }

    private Vector3 previousPosition;

    private Queue<Sample> deltas = new Queue<Sample>();

    private void Update()
    {
        Vector3 currentPosition = cachedTransform.position;
        Vector3 delta = currentPosition - previousPosition;
        float scale = Time.deltaTime;

        Sample sample = new Sample(scale, delta);
        deltas.Enqueue(sample);

        // not very optimized here. 
        AdjustSampleSize();
        previousPosition = currentPosition;
    }

    private void AdjustSampleSize()
    {
        while (SampleTotalDuration > Duration)
        {
            deltas.Dequeue();
        }
    }

    private struct Sample
    {
        public readonly float DeltaTime;
        public readonly Vector3 RawOffset;
        public readonly Vector3 DeltaMovement;

        public Sample(float deltaTime, Vector3 rawOffset)
        {
            DeltaTime = deltaTime;
            RawOffset = rawOffset;
            DeltaMovement = new Vector3(RawOffset.x / deltaTime, RawOffset.y / deltaTime, RawOffset.z / deltaTime);
        }
    }
}
