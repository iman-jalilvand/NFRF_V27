using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nob : Base
{
	public float MinValue = 150;
	public float MaxValue = 500;

	public bool On = false;

	private float value = 150;
	public float Value {
		get {
			if(On == false || !gameObject.activeInHierarchy) {
				return 0;
			}

			return value;
		}

		set
		{
			this.value = value;
		}
	}


	public GameObject OnButton;
	public GameObject OffButton;

	private void Start()
	{
		OnButton.SetActive(On);
		OffButton.SetActive(!On);
	}


	public void SliderChanged(SliderEventData data)
	{
		Value = Mathf.Lerp(MinValue, MaxValue, data.NewValue);
	}

	public void FlipSwitch()
	{
		On = !On;
		OnButton.SetActive(On);
		OffButton.SetActive(!On);
			Broadcast("Power", On);
	}
}
