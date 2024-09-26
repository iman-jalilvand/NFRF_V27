using UnityEngine;
using System.Collections;

public class EnableColliderOnEnable : MonoBehaviour {
    [UnityEngine.Serialization.FormerlySerializedAs("c")]
	public Collider ReferencedCollider;
    private void OnEnable() {
        ReferencedCollider.enabled = true;
    }
}
