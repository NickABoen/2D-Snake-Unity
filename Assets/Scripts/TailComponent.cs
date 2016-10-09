using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TailComponent : MonoBehaviour {
    public Vector2 position;
    public static GameObject tail_prefab;
    public TailComponent tail;

    public void UpdatePosition(Vector2 newPosition, bool add_tail)
    {
        if (tail != null)
        {
            tail.UpdatePosition(position, add_tail);
        }
        else if (add_tail)
        {
            tail = TailComponent.Spawn();
            tail.transform.position = position;
            tail.UpdatePosition(position, !add_tail);
        }
        position = newPosition;
    }

    public static TailComponent Spawn()
    {
        TailComponent result = Instantiate(tail_prefab).GetComponent<TailComponent>();

        return result;
    }
}
