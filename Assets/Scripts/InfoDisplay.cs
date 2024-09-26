using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoDisplay : MonoBehaviour
{
	public TMPro.TMP_Text TemperatureDisplay;
	public TMPro.TMP_Text PowerDisplay;

	public Heater target;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			Debug.DrawRay(r.origin, r.direction, Color.red, 500);
			if (Physics.Raycast(r.origin, r.direction, out hit, 100))
			{
				Heater h = hit.transform.GetComponent<Heater>();
				target = h;
			}
		}
		Display(target);
	}

	private void Display(Heater h)
	{
		if (h == null)
		{
			return;
		}

		PowerDisplay.text = h.PowerConsumption.ToString();
		TemperatureDisplay.text = h.Temperature.ToString();
	}

	public void SetTarget(Heater h)
    {
		target = h;
    }
}
