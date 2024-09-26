using UnityEngine;
using System.Collections;
using UnityEngine.Serialization;

public class IntInterface : Base
{
    public int MinValue = 0;
    [TooltipAttribute("Inclusive")]
    public int MaxValue = 100;
    public int StartValue = 100;
    private int value;
    public int Value
    {
        get
        {
            return value;
        }
        set
        {
            int result = Mathf.Clamp(value, MinValue, MaxValue);
            if (result != this.value)
            {
                this.value = result;
                if (this.value == MinValue)
                {
                    Call(OnValueReachedMin, cachedGameObject);
                }
                else if (this.value == MaxValue)
                {
                    Call(OnValueReachedMax, cachedGameObject);
                }
                Call(OnValueChanged, cachedGameObject, this.value);
                Call(OnRateChanged, cachedGameObject, (float)this.value / (float)MaxValue);
            }
        }
    }

    public string CallSetMax;
    public string CallSetMin;
    public string CallSetStart;
    public string CallAdd;
    public string CallSubtract;
    public string CallIncrementByOne;
    public string CallDecrementByOne;
    public string CallReset;
    public string CallGetValue;
    public string OnValueReachedMin;
    public string OnValueReachedMax;
    public string OnValueChanged;
    public string OnRateChanged;
    public string OnGetValue;
    public bool ResetOnEnable = true;


    private void Awake()
    {
        StartValue = Mathf.Clamp(StartValue, MinValue, MaxValue);
        Value = StartValue;

        CacheMethod(CallAdd, Add);
        CacheMethod(CallSubtract, Subtract);
        CacheMethod(CallIncrementByOne, IncrementByOne);
        CacheMethod(CallDecrementByOne, DecrementByOne);
        CacheMethod(CallReset, ResetHealth);
        CacheMethod(CallGetValue, GetValue);
        CacheMethod(CallSetMax, SetMax);
        CacheMethod(CallSetMin, SetMin);
        CacheMethod(CallSetStart, SetStart);
    }
    protected void SetMax(object o)
    {
        int i;
        if (o is int)
        {
            i = (int)o;
            MaxValue = i;
        }
        else if (o is float)
        {
            i = (int)(float)o;
            MaxValue = i;
        }
        else if (int.TryParse(o.ToString(), out i))
        {
            MaxValue = i;
        }
    }
    protected void SetMin(object o)
    {
        int i;
        if (o is int)
        {
            i = (int)o;
            MinValue = i;
        }
        else if (o is float)
        {
            i = (int)(float)o;
            MinValue = i;
        }
        else if (int.TryParse(o.ToString(), out i))
        {
            MinValue = i;
        }
    }
    protected void SetStart(object o)
    {
        int i;
        if (o is int)
        {
            i = (int)o;
            StartValue = i;
        }
        else if (o is float)
        {
            i = (int)(float)o;
            StartValue = i;
        }
        else if (int.TryParse(o.ToString(), out i))
        {
            StartValue = i;
        }
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        ResetHealth(null);
    }

    private void Subtract(object o)
    {
        if (o is int)
        {
            Value -= (int)o;
        }
    }

    private void Add(object o)
    {
        if (o is int)
        {
            Value += (int)o;
        }
    }

    private void IncrementByOne(object o)
    {
        Value++;
    }

    private void DecrementByOne(object o)
    {
        Value--;
    }

    private void GetValue(object o)
    {
        Call(OnGetValue, cachedGameObject, Value);
    }

    private void ResetHealth(object o)
    {
        Value = StartValue;
    }
}
