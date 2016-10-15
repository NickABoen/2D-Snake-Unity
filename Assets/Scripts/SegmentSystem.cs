using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SegmentSystem : MonoBehaviour {
    public GameObject Head_Prefab, Segment_Prefab;

    FollowerComponent Head, Tail;
    List<FollowerComponent> Segment_list;
    TimerSystem timer_system;

    public int Size;
    int current_size;

    TimerComponent step_timer;
    Vector2 direction;

    public void UpdatePositions()
    {

    }

    void AddSegment()
    {

    }

    void ChangeDirection(Vector2 newDirection)
    {

    }
}
