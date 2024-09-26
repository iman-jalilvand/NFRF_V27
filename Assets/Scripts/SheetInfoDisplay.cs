using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SheetInfoDisplay : MonoBehaviour
{
	private TMPro.TMP_Text temperatureDisplay;
	public TMPro.TMP_Text TemperatureDisplay
    {
		get
        {
			if(temperatureDisplay == null)
            {
				GameObject go = GameObject.FindGameObjectWithTag("HandAttachedDisplay");
				if(go != null) {
					temperatureDisplay = go.GetComponent<TMPro.TMP_Text>();
				}
            }

			return temperatureDisplay;
        }
    }
	public int x
    {
		get
        {
			return SheetSurface.Instance.Sections.Find((s) =>
			{
				return s.Target == gameObject;
			}).X;
        }
    }

	public int y
	{
		get
		{
			return SheetSurface.Instance.Sections.Find((s) =>
			{
				return s.Target == gameObject;
			}).Z;
		}
	}

	public double[,] SheetTemperatures
    {
		get
        {
			return HeatManagement.Instance.SheetTemperatures;
        }
    }

    private void Update()
	{
		Display();
	}

	private void Display()
	{
		if(TemperatureDisplay == null)
        {
			return;
        }

		TemperatureDisplay.text = SheetTemperatures[x, y].ToString("F1");
	}
}
