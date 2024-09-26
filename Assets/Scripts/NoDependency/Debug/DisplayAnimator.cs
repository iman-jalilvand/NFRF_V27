using UnityEngine;
using System.Collections.Generic;

public class DisplayAnimator : MonoBehaviour {
	[UnityEngine.Serialization.FormerlySerializedAs("tm")]
	public TextMesh ReferencedTextMesh;
	[UnityEngine.Serialization.FormerlySerializedAs("animator")]
	public Animator ReferencedAnimator;
	[UnityEngine.Serialization.FormerlySerializedAs("stateNames")]
	public string[] StateNames;
	
    private void Start()
    {
        ReferencedAnimator = GetComponentInParent<Animator>();
    }

	void Update () {
		List<string> names = new List<string>();
		for(int layer = 0, max = ReferencedAnimator.layerCount; layer < max; ++layer) {
			AnimatorStateInfo info = ReferencedAnimator.GetCurrentAnimatorStateInfo(layer);
			foreach(string name in StateNames) {
				if(info.IsName(name)) {
					names.Add(name);
				}
			}
		}

		string content = "";
		foreach(string name in names) {
			content += name + '\n';
		}
		ReferencedTextMesh.text = content;
	}
}
