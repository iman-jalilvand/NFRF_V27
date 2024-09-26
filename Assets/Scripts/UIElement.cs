using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIElement : Base, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
	public string OnMouseEnter;
	public string OnMouseExit;
	public string OnClick;

	public void OnPointerExit(PointerEventData eventData)
	{
		Call(OnMouseExit, cachedGameObject);
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		Call(OnMouseEnter, cachedGameObject);
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Call(OnClick, cachedGameObject);
	}
}
