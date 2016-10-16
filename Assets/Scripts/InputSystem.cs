using UnityEngine;
using System.Collections;

public class InputSystem : Singleton<InputSystem>{
    public enum InputDirection { NONE, LEFT, RIGHT };
    public InputDirection Direction;

	// Update is called once per frame
	void Update () {
        float input_value = Input.GetAxis("Horizontal");
        if(input_value > 0)
        {
            Direction = InputDirection.RIGHT;
        }
        else if(input_value < 0)
        {
            Direction = InputDirection.LEFT;
        }
        else
        {
            Direction = InputDirection.NONE;
        }
	}
}
