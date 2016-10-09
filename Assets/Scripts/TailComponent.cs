using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TailComponent : MonoBehaviour {
    public Vector2 position;
    public GameObject tail_prefab;
    public TailComponent tail;

    public void UpdatePosition(Vector2 newPosition, bool add_tail)
    {
        if (tail != null)
        {
            tail.UpdatePosition(position, tails_to_add);
        }
        else if (add_tail)
        {
            tail = Spawn();
            tail.UpdatePosition(position, !add_tail);
        }
        position = newPosition;
    }

    public TailComponent Spawn()
    {
        TailComponent result = Instantiate(tail_prefab).GetComponent<TailComponent>();
        result.transform.position = position;

        return result;
    }
}
