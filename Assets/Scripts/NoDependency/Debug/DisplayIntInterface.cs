using UnityEngine;
using System.Collections;

public class DisplayIntInterface : MonoBehaviour {
	[UnityEngine.Serialization.FormerlySerializedAs("target")]
	public IntInterface Target;
	[UnityEngine.Serialization.FormerlySerializedAs("tm")]
	public TextMesh ReferencedTextMesh;
	void Update () {
		ReferencedTextMesh.text = Target.Value.ToString();
	}
}
