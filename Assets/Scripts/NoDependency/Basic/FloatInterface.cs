using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;
using System;

public class FloatInterface : Base
{
	public float MinValue = 0;
	public float MaxValue = 100;
	public float StartValue = 100;
	private float value;
	public float Value
	{
		get
		{
			return value;
		}
		set
		{
			float result = Mathf.Clamp(value, MinValue, MaxValue);
			if (result != this.value) {
				this.value = result;
				if (this.value == MinValue) {
					Call(OnValueReachedMin, cachedGameObject);
				}
				Call(OnValueChanged, cachedGameObject, this.value);
				Call(OnValueChangedInFraction, cachedGameObject, this.value / this.MaxValue);
			}
		}
	}
	public string CallSetMax;
	public string CallSetMin;
	public string CallSetStart;
	public string CallModStart;
	public string CallAdd;
	public string CallSubtract;
	public string CallReset;
	public string CallDecrement;
	public string CallIncrement;
	public string CallSet;
	public string CallGetMax;
	public string CallModMax;
	public string CallGetFractionInDecimal;
	public string OnValueReachedMin;
	public string OnValueReachedMax;
	public string OnValueChanged;
	public string OnValueChangedInFraction;
	public string CallGet;
	public string OutgoingOnGet;
	public string OutgoingOnGetMax;
	public string OutgoingOnGetFractionInDecimal;

	public bool ResetOnEnable = true;


	private void Awake()
	{
		StartValue = Mathf.Clamp(StartValue, MinValue, MaxValue);
		Value = StartValue;

		CacheMethod(CallAdd, Add);
		CacheMethod(CallSubtract, Subtract);
		CacheMethod(CallReset, ResetValue);
		CacheMethod(CallIncrement, Increment);
		CacheMethod(CallDecrement, Decrement);
		CacheMethod(CallSet, Set);
		CacheMethod(CallGet, Get);
		CacheMethod(CallGetMax, GetMax);
		CacheMethod(CallGetFractionInDecimal, GetFractionInDecimal);
		CacheMethod(CallSetMax, SetMax);
		CacheMethod(CallSetMin, SetMin);
		CacheMethod(CallSetStart, SetStart);
		CacheMethod(CallModStart, ModStart);
		CacheMethod(CallModMax, ModMax);
	}

	private void Start()
	{
	}

	protected void ModStart(object o)
	{
		bool isFloat = true;
		float i;
		if (o is float) {
			i = (float)o;
		} else if (o is int) {
			i = (float)(int)o;
		} else if (float.TryParse(o.ToString(), out i)) {
		} else {
			isFloat = false;
		}

		if (isFloat) {
			StartValue = StartValue + i;
		}
	}

	protected void ModMax(object o)
	{
		bool isFloat = true;
		float i;
		if (o is float) {
			i = (float)o;
		} else if (o is int) {
			i = (float)(int)o;
		} else if (float.TryParse(o.ToString(), out i)) {
		} else {
			isFloat = false;
		}

		if (isFloat) {
			MaxValue = MaxValue + i;
			if (i > 0) {
				Value = value + i;
			}
		}
	}

	protected void SetMax(object o)
	{
		float i;
		if (o is float) {
			i = (float)o;
			MaxValue = i;
		} else if (o is int) {
			i = (float)(int)o;
			MaxValue = i;
		} else if (float.TryParse(o.ToString(), out i)) {
			MaxValue = i;
		}
	}
	protected void SetMin(object o)
	{
		float i;
		if (o is float) {
			i = (float)o;
			MinValue = i;
		} else if (o is float) {
			i = (float)(int)o;
			MinValue = i;
		} else if (float.TryParse(o.ToString(), out i)) {
			MinValue = i;
		}
	}
	protected void SetStart(object o)
	{
		float i;
		if (o is float) {
			i = (float)o;
			StartValue = i;
		} else if (o is int) {
			i = (float)(int)o;
			StartValue = i;
		} else if (float.TryParse(o.ToString(), out i)) {
			StartValue = i;
		}
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		if (ResetOnEnable) {
			ResetValue(null);
		}
	}

	private void Set(object o)
	{
		float f;
		if (o is float) {
			Value = (float)o;
		} else if (o != null && float.TryParse(o.ToString(), out f)) {
			Value = f;
		}
	}

	private void Get(object o)
	{
		Call(OutgoingOnGet, cachedGameObject, Value);
	}

	private void GetMax(object o)
	{
		Call(OutgoingOnGetMax, cachedGameObject, MaxValue);
	}

	private void GetFractionInDecimal(object o)
	{
		Call(OutgoingOnGetFractionInDecimal, cachedGameObject, Value / MaxValue);
	}

	private void Subtract(object o)
	{
		float f;
		if (o is float) {
			Value -= (float)o;
		} else if (o != null && float.TryParse(o.ToString(), out f)) {
			Value -= f;
		}
	}

	private void Add(object o)
	{
		float f;
		if (o is float) {
			Value += (float)o;
		} else if (o != null && float.TryParse(o.ToString(), out f)) {
			Value += f;
		}
	}

	private void Increment(object o)
	{
		Value += 1;
	}

	private void Decrement(object o)
	{
		Value -= 1;
	}

	private void ResetValue(object o)
	{
		Value = StartValue;
	}
}
