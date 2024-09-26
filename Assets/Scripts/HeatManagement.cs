using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatManagement : MonoBehaviour
{
	public static HeatManagement Instance;

	public Heater[] Heaters;
	public SheetSurface Sheet;
	public double[,] SheetTemperatures;



	public Color GetTemperatureColor(float temperature)
	{
		float LowTemperatureDegree = 0f;
		float HighTemperatureDegree = 500;
		float temp = Mathf.InverseLerp(LowTemperatureDegree, HighTemperatureDegree, temperature);
		float hue = Mathf.Lerp(170 / 255f, 0, temp);
		return Color.HSVToRGB(hue, 1, 1);
	}

	private void Awake()
	{
		Instance = this;
		Heaters = GetComponentsInChildren<Heater>();
	}

	public void SetPower(double[] Power)
	{
		for (int i = 0, max = Power.Length; i < max; ++i)
		{
			Heaters[i].PowerConsumption = (float)Power[i];
		}
	}

	public void SetTemperature(double[] Temperatures)
	{
		for (int i = 0, max = Temperatures.Length; i < max; ++i)
		{
			Heaters[i].Temperature = (float)Temperatures[i];
		}
	}

	public void SetSheetTemperature(double[,] a)
	{
		if(!Sheet.gameObject.activeInHierarchy)
		{
			return;
		}
		SheetTemperatures = a;
		for (int x = 0; x < a.GetLength(0); ++x)
		{
			for(int z = 0; z < a.GetLength(1); ++z) {
				Color c = GetTemperatureColor((float)a[x, z]);
				Material m = Sheet.CubeMaterials[x, z].material;
				m.color = c;
				Sheet.CubeMaterials[x, z].material = m;
			}
		}
	}
}
