using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SegmentSystem : MonoBehaviour {
    public GameObject Head_Prefab, Segment_Prefab;
    public int Size;

    FollowerComponent Head, Tail;
    List<FollowerComponent> Segment_list;
    TimerSystem timer_system;

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
