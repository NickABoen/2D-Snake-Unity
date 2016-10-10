using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerSystem : MonoBehaviour
{
    private List<TimerComponent> Timers;

    void Awake()
    {
        Timers = new List<TimerComponent>();
    }

    void Update()
    {
        foreach (TimerComponent tc in Timers)
        {
            Tick_Component(tc);
        }
    }

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
}
