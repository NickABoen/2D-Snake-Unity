using UnityEngine;
using UnityEngine.Events;
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
    public Direction DefaultDirection;
    public float Step_time = 1;
    public Vector2 StartPosition;
    public int Size;

    public Vector2 Position
    {
        get { if (Segment_list.Count > 0) return Segment_list[0].position; else return Vector2.zero; }
        set { if(Segment_list.Count > 0) Segment_list[0].position = value; }
    }

    List<FollowerComponent> Segment_list;
    TimerSystem timer_system;

    TimerComponent step_timer;
    Direction direction;

    void Awake()
    {
        Segment_list = new List<FollowerComponent>();
        direction = DefaultDirection;
        UnityEvent update_event = new UnityEvent();
        update_event.AddListener(new UnityAction(UpdatePositions));
        step_timer = TimerComponent.CreateComponent(gameObject, Step_time, update_event, true, false);
        step_timer.name = "Segment System Timer";
        step_timer.Stop();
    }

    void Start()
    {
        timer_system = gameObject.GetComponent<TimerSystem>();
        if(timer_system != null)
        {
            timer_system.AddTimer(step_timer);
        }
    }

    void OnEnable()
    {
        step_timer.Play();
    }

    void OnDisable()
    {
        step_timer.Stop();
    }

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
        if(Size > Segment_list.Count)
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
        GameObject new_segment = ComponentFactory.CreateSnakeSegment(Segment_list.Count == 0);
        FollowerComponent segment_component = new_segment.GetComponent<FollowerComponent>();

        if(Segment_list.Count == 0)
        {
            segment_component.position = StartPosition;
        }

        return segment_component;
    }
}
