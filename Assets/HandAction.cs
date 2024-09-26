using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandAction : Base, IMixedRealityInputActionHandler, IMixedRealityGestureHandler
{
	public Text text;
	Queue<string> hist = new Queue<string>();

	private Dictionary<uint, Microsoft.MixedReality.Toolkit.Utilities.Handedness> Hand = new Dictionary<uint, Microsoft.MixedReality.Toolkit.Utilities.Handedness>();

	public void OnActionEnded(BaseInputEventData eventData)
	{
		Enter("Action Canceled: " + eventData.MixedRealityInputAction.Description);
		Broadcast("HandEnd", eventData.MixedRealityInputAction.Description);
	}

	public void OnActionStarted(BaseInputEventData eventData)
	{
		Enter("Action Started: " + eventData.MixedRealityInputAction.Description);
		Broadcast("HandStart", eventData.MixedRealityInputAction.Description);
	}



	private void Enter(string str)
	{
		hist.Enqueue(str);
		hist.Dequeue();
		Display();
	}

	// Start is called before the first frame update
	void Start()
    {
		for(int i = 0; i < 10; ++i)
			hist.Enqueue("...");
		Display();
	}

	private void Display()
	{
		if(text == null) {
			return;
		}

		string str = "";
		foreach(string line in hist) {
			str += line + '\n';
		}
		text.text = str;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void OnGestureStarted(InputEventData eventData)
	{
		Hand[eventData.SourceId] = eventData.Handedness;
		//Enter("Gesture Started: " + eventData.MixedRealityInputAction.Description);
		//Broadcast(eventData.Handedness == Microsoft.MixedReality.Toolkit.Utilities.Handedness.Right ? "RightHandStart" : "LeftHandStart", eventData.MixedRealityInputAction.Description);
	}

	public void OnGestureUpdated(InputEventData eventData)
	{
		//
	}

	public void OnGestureCompleted(InputEventData eventData)
	{
		Hand[eventData.SourceId] = eventData.Handedness;
		//Enter("Gesture Completed: " + eventData.MixedRealityInputAction.Description);
		//Broadcast(eventData.Handedness == Microsoft.MixedReality.Toolkit.Utilities.Handedness.Right ? "RightHandEnd" : "LeftHandEnd", eventData.MixedRealityInputAction.Description);
	}

	public void OnGestureCanceled(InputEventData eventData)
	{
		Hand[eventData.SourceId] = eventData.Handedness;
		//Enter("Gesture Canceled: " + eventData.MixedRealityInputAction.Description);
		//Broadcast(eventData.Handedness == Microsoft.MixedReality.Toolkit.Utilities.Handedness.Right ? "RightHandEnd" : "LeftHandEnd", eventData.MixedRealityInputAction.Description);
	}
}
