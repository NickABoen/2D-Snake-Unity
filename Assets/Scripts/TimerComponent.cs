using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour
{
    public bool Recurring;
    public bool DestroyWhenFinished;

    public float TotalTime = 1.0f;
    public UnityEvent OnTimeOut;

    private float time_left = 1.0f;
    private bool isPaused;
    private bool isStopped;

    public static TimerComponent CreateComponent(GameObject source, 
        float totalTime, UnityEvent onTimeOut, bool recurring = false, bool destroyWhenFinished = false)
    {
        TimerComponent new_component = source.AddComponent<TimerComponent>();
        new_component.Recurring = recurring;
        new_component.DestroyWhenFinished = destroyWhenFinished;
        new_component.TotalTime = totalTime;
        if(onTimeOut != null)
            new_component.OnTimeOut = onTimeOut;
        return new_component;
    }

    /// <summary>
    /// Initialize private variables where necessary when created
    /// </summary>
    void Awake()
    {
        time_left = TotalTime;
        if (OnTimeOut == null)
        {
            OnTimeOut = new UnityEvent();
        }
    }

    /// <summary>
    /// Reduce timer by Time.deltaTime value
    /// </summary>
    public void Tick()
    {
        time_left -= Time.deltaTime;
    }

    /// <summary>
    /// Invoke the OnTimeOut delegate
    /// </summary>
    public void Trigger()
    {
        OnTimeOut.Invoke();
    }

    /// <summary>
    /// Continue the timer if it was paused; restart it if stopped; do nothing otherwise
    /// </summary>
    public void Play()
    {
        isPaused = false;
        if (isStopped) Restart();
    }

    /// <summary>
    /// Pause the timer and prevent it from being ticked until continued
    /// </summary>
    public void Pause()
    {
        isPaused = true;
    }

    /// <summary>
    /// Restart the timer at its max value
    /// </summary>
    public void Restart()
    {
        time_left = TotalTime;
        isStopped = false;
    }

    /// <summary>
    /// Stop the timer completely and prevent it from being ticked until restarted
    /// </summary>
    public void Stop()
    {
        isStopped = true;
    }

    /// <summary>
    /// Check if the timer can be ticked
    /// </summary>
    /// <returns>True if the timer will be ticked, false if paused or stopped</returns>
    public bool CanTick()
    {
        return !(isStopped || isPaused);
    }

    /// <summary>
    /// Check if the timer has been stopped
    /// </summary>
    /// <returns>true if stopped</returns>
    public bool Stopped()
    {
        return isStopped;
    }

    /// <summary>
    /// Check if the timer has been paused
    /// </summary>
    /// <returns>true if paused</returns>
    public bool Paused()
    {
        return isPaused;
    }

    /// <summary>
    /// Check if the timer has finished and is still active
    /// </summary>
    /// <returns>true if the timer is not stopped and has exceeded its duration</returns>
    public bool TimesUp()
    {
        return (CanTick() && time_left <= 0.0f);
    }
}
