using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {
    [MultilineAttribute(10)]
    [UnityEngine.Serialization.FormerlySerializedAs("content")]
	public string Content;
}
