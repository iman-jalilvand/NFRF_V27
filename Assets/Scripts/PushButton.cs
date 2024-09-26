using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{

	public bool On = false;
	public GameObject OnButton;
	public GameObject OffButton;

	private void Start()
	{
		OnButton.SetActive(On);
		OffButton.SetActive(!On);
	}

	public void FlipSwitch()
	{
		On = !On;
		OnButton.SetActive(On);
		OffButton.SetActive(!On);
	}
}
