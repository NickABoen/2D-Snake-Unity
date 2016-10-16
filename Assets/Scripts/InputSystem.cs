using UnityEngine;
using System.Collections;

public class InputSystem : Singleton<InputSystem>{
    public enum InputDirection { NONE, LEFT, RIGHT };
    public InputDirection Direction;
    float previous_axis_value, axis_value;

	// Update is called once per frame
	void Update () {
        previous_axis_value = axis_value;
        axis_value = Input.GetAxis("Horizontal");

        if (axis_value > 0.0f && previous_axis_value == 0.0f)
        {
            Direction = InputDirection.RIGHT;
        }
        else if(axis_value < 0.0f && previous_axis_value == 0.0f)
        {
            Direction = InputDirection.LEFT;
        }
        else
        {
            Direction = InputDirection.NONE;
        }
	}
}
