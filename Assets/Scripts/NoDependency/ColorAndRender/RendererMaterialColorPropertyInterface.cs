using UnityEngine;
using System.Collections;

public class RendererMaterialColorPropertyInterface : Base {
	[UnityEngine.Serialization.FormerlySerializedAs("renderer")]
	public Renderer ReferencedRenderer;
	[UnityEngine.Serialization.FormerlySerializedAs("propertyName")]
	public string PropertyName;
	[UnityEngine.Serialization.FormerlySerializedAs("callSetColor")]
	public string CallSetColor;

	private Material material;

	private void Awake()
	{	
		CacheMethod(CallSetColor, SetColor);
		material = ReferencedRenderer.material;
	}

	private void SetColor(object o)
	{
		if(!(o is Color)) {
			return;
		}

		Color c = (Color) o;
		material.SetColor(PropertyName, c);
	}
}
