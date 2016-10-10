using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerSystem : MonoBehaviour {
    private List<TimerComponent> GeneralTimers;
    private List<TimerComponent> DestructableTimers;

    void Awake()
    {
        GeneralTimers = new List<TimerComponent>();
        DestructableTimers = new List<TimerComponent>();
    }

    void Update()
    {
        foreach(TimerComponent tc in GeneralTimers)
        {
        }
        foreach(TimerComponent tc in DestructableTimers)
        {
        }
    }
}
