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
        if(Size < Segment_list.Count)
        {
        }

        Vector2 next_position = Vector2.zero;
        Vector2 new_position = Vector2.zero;
        foreach(FollowerComponent segment in Segment_list)
        {
            if (segment.IsLeader)
            {
                next_position = segment.position + direction;
            }

            new_position = next_position;
            next_position = segment.position;
            segment.position = new_position;
        }
    }

    void AddSegment()
    {

    }

    void ChangeDirection(Vector2 newDirection)
    {

    }
}
