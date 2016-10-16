using UnityEngine;
using System.Collections;

public class FollowerComponent : MonoBehaviour {
    public bool IsLeader;
    public Vector2 position
    {
        get { return gameObject.transform.position; }
        set { gameObject.transform.position = value; }
    }
}
