using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FPS : MonoBehaviour {
	[UnityEngine.Serialization.FormerlySerializedAs("sampleCount")]
	public int SampleCount = 10;
	private Text textComponent;
	private TextMesh textMesh;
	private Queue<float> deltaTimes = new Queue<float>();

	private float AverageFPS
	{
		get {
			float fps = 0;
			foreach(float deltaTime in deltaTimes)
			{
				fps += deltaTime;
			}
			if (deltaTimes.Count != 0)
			{
				fps /= deltaTimes.Count;
			}

			return 1 / fps;
		}
	}

	void Start () {
		Application.targetFrameRate = 120;
		textComponent = GetComponent<Text>();
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		deltaTimes.Enqueue(Time.deltaTime);
		if(deltaTimes.Count > SampleCount) {
			deltaTimes.Dequeue();
		}
		if (textMesh != null)
		{
			textMesh.text = AverageFPS.ToString();
		}
		if (textComponent != null)
		{
			textComponent.text = AverageFPS.ToString();
		}
	}
}
