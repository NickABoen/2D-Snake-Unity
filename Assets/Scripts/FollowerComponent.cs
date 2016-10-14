using UnityEngine;
using System.Collections;

public class FollowerComponent : MonoBehaviour {
    public bool IsLeader;
    public FollowerComponent Tail = null;
    public Vector2 position
    {
        get { return gameObject.transform.position; }
        set { gameObject.transform.position = value; }
    }

    public void UpdatePositions(Vector2 newPosition)
    {
        if(Tail != null)
        {
            Tail.UpdatePositions(this.position);
        }

        this.position = newPosition;
    }
}
