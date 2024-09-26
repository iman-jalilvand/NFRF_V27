using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Heater : MonoBehaviour
{
    public float PowerConsumption = 0;
    public float SurfaceTemperature = 0;

    public MeshRenderer Renderer;

    public float LowTemperatureDegree = -273.15f;
    public float HighTemperatureDegree = 500;

    public float Temperature = 0;
    public Color TemperatureColor
    {
        get {
            float temp = Mathf.InverseLerp(LowTemperatureDegree, HighTemperatureDegree, Temperature);
            float hue = Mathf.Lerp(170/255f, 0, temp);
            return Color.HSVToRGB(hue, 1, 1);
		}
    }

    private TMPro.TMP_Text temperatureDisplay;
    public TMPro.TMP_Text TemperatureDisplay
    {
        get
        {
            if (temperatureDisplay == null)
            {
                var scripts = GetComponentsInChildren<TMPro.TMP_Text>(true);
                temperatureDisplay = scripts.First((s) =>
                {
                    return s.transform.parent.name == "Data";
                });
            }

            return temperatureDisplay;
        }
    }

    void Update()
    {
        Material m = Renderer.material;
        m.color = TemperatureColor;
        Renderer.material = m;
        TemperatureDisplay.text = Temperature.ToString("F3");
    }
}
