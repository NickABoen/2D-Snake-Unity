using UnityEngine;
using System.Collections;

public class PlayerSystem : MonoBehaviour {
    public HeadComponent playerHead;

    private Vector2 temp_direction;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void MoveLeft()
    {
        temp_direction = Vector2.left;
    }

    public void MoveRight()
    {
        temp_direction = Vector2.right;
    }

    public void MoveUp()
    {
        temp_direction = Vector2.up;
    }

    public void MoveDown()
    {
        temp_direction = Vector2.down;
    }
}
