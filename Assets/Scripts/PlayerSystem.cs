using UnityEngine;
using System.Collections;

public class PlayerSystem : MonoBehaviour {
    public HeadComponent playerHead;
    public int StartingSegments = 3;

    private Vector2 temp_direction;

	// Use this for initialization
	void Start () {
	    
	}

    public void Spawn(Vector2 position)
    {
        playerHead = Instantiate(HeadComponent.Head_Prefab).GetComponent<HeadComponent>();
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
