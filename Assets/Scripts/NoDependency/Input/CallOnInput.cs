using UnityEngine;
using System.Collections;

public class CallOnInput : Base {
    public KeyCode input;
    public string methodName, parameter;
    public Behaviour onInput;
	public ParamType paramType;
	public InputType inputType = InputType.Down;

	private object Parameter
	{
		get {
			object o = null;
			switch(paramType) {
				case ParamType.Float:
				o = float.Parse(parameter);
				break;
				case ParamType.Int:
				o = int.Parse(parameter);
				break;
				case ParamType.String:
				o = parameter;
				break;
			}
			return o;
		}
	}

    private void Update()
    {
        if(	(inputType == InputType.Down && Input.GetKeyDown(input)) ||
			(inputType == InputType.Up && Input.GetKeyUp(input)) ||
			(inputType == InputType.Pressed && Input.GetKey(input)))
        {
            HandleBehaviour(onInput);
        }
    }

    private void HandleBehaviour(Behaviour b)
    {
        switch(b)
        {
            case Behaviour.Call:
                Call(methodName, cachedGameObject, Parameter);
                break;
            case Behaviour.Broadcast:
                Call(methodName, typeof(Base), Parameter);
                break;
        }
    }

    public enum Behaviour
    {
        Call, 
        Broadcast
    }

	public enum ParamType
	{
		String, 
		Float, 
		Int
	}

	public enum InputType
	{
		Down,
		Up,
		Pressed
	}
}
