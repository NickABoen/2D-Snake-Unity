using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerSystem : MonoBehaviour
{
    private List<TimerComponent> Timers;
    private List<TimerComponent> DeletionList;

    /// <summary>
    /// Initialize list of timers upon creation
    /// </summary>
    void Awake()
    {
        Timers = new List<TimerComponent>();
        DeletionList = new List<TimerComponent>();
    }

    /// <summary>
    /// Tick each component on Update
    /// </summary>
    void Update()
    {
        foreach (TimerComponent tc in Timers)
        {
            if (tc == null)
                DeletionList.Add(tc);
            else
                Tick_Component(tc);
        }

        if (DeletionList.Count > 0)
        {
            foreach (TimerComponent tc in DeletionList)
            {
                RemoveTimer(tc);
            }
            DeletionList.Clear();
        }
    }

    /// <summary>
    /// Method for performing a 'tick' on a given timer
    /// </summary>
    /// <param name="tc">timer to 'tick'</param>
    private void Tick_Component(TimerComponent tc)
    {
        if (tc.CanTick())
        {
            tc.Tick();

            if (tc.TimesUp())
            {
                tc.Trigger();

                if (tc.DestroyWhenFinished)
                {
                    Timers.Remove(tc);
                    Destroy(tc);
                }
                else if (tc.Recurring)
                {
                    tc.Restart();
                }
                else
                {
                    tc.Stop();
                }
            }
        }
    }

    /// <summary>
    /// Add a new timer to the list of timers and start ticking it
    /// </summary>
    /// <param name="new_timer">new timer to add</param>
    public void AddTimer(TimerComponent new_timer)
    {
        if (!Timers.Contains(new_timer))
        {
            Timers.Add(new_timer);
        }
    }

    /// <summary>
    /// Remove a timer from the list of ticked timers and stop ticking it
    /// </summary>
    /// <param name="timer">timer to remove</param>
    public void RemoveTimer(TimerComponent timer)
    {
        Timers.Remove(timer);
    }
}
