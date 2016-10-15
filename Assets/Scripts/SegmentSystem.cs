using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum Direction
{
    RIGHT,
    DOWN,
    LEFT,
    UP
}

public class SegmentSystem : MonoBehaviour {
    public GameObject Head_Prefab, Segment_Prefab;
    public Direction DefaultDirection;
    public int Size;

    FollowerComponent Head, Tail;
    List<FollowerComponent> Segment_list;
    TimerSystem timer_system;

    int current_size;

    TimerComponent step_timer;
    Direction direction;

    public void UpdatePositions()
    {
        AddSegment();

        Vector2 direction_value;
        switch (direction)
        {
            case Direction.UP:
                direction_value = Vector2.up;
                break;
            case Direction.DOWN:
                direction_value = Vector2.down;
                break;
            case Direction.LEFT:
                direction_value = Vector2.left;
                break;
            case Direction.RIGHT:
                direction_value = Vector2.right;
                break;
            default:
                direction_value = Vector2.zero;
                break;
        }

        Vector2 next_position = Vector2.zero;
        Vector2 new_position = Vector2.zero;
        foreach(FollowerComponent segment in Segment_list)
        {
            if (segment.IsLeader)
            {
                next_position = segment.position + direction_value;
            }

            new_position = next_position;
            next_position = segment.position;
            segment.position = new_position;
        }
    }

    void AddSegment()
    {
        if(Size < Segment_list.Count)
        {
            Segment_list.Add(CreateSegment());
        }
    }

    void ChangeDirection(Direction newDirection)
    {
        switch (direction)
        {
            case Direction.DOWN:
                direction = (newDirection == Direction.UP) ? direction : newDirection;
                break;
            case Direction.LEFT:
                direction = (newDirection == Direction.RIGHT) ? direction : newDirection;
                break;
            case Direction.RIGHT:
                direction = (newDirection == Direction.LEFT) ? direction : newDirection;
                break;
            case Direction.UP:
                direction = (newDirection == Direction.DOWN) ? direction : newDirection;
                break;
            default:
                direction = DefaultDirection;
                break;
        }
    }

    FollowerComponent CreateSegment()
    {

    }
}
