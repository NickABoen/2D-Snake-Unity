using UnityEngine;
using System.Collections;

public class HeadComponent : MonoBehaviour {
    public Vector2 position;
    public Vector2 direction = Vector2.right;
    public TailComponent tail;

    public int Size = 1;
    private int current_size = 1;

    public void UpdatePosition()
    {
        bool add_tail = current_size < Size;
        if (tail != null)
        {
            tail.UpdatePosition(position, add_tail);
        }
        else if (add_tail)
        {
            tail = TailComponent.Spawn();
            tail.UpdatePosition(position, false);
        }
        if (add_tail) current_size++;
        position += direction;
    }

    public void AddSegment()
    {
        Size++;
    }
}
