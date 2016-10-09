using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour {
    public bool Recurring;
    public bool DestroyWhenFinished;

    public float TotalTime = 1.0f;
    public UnityEvent OnTimeOut;

    private float time_left = 1.0f;
    private bool isPaused;
    private bool isStopped;

    void Awake()
    {
        time_left = TotalTime;
        if(OnTimeOut == null)
        {
            OnTimeOut = new UnityEvent();
        }
    }

	void Tick() {
        if (!(isStopped || isPaused))
        {
            time_left -= Time.deltaTime;

            if (time_left <= 0.0f)
            {
                OnTimeOut.Invoke();
                if (DestroyWhenFinished)
                {
                    //Invoke destruction in Timer System
                }
                else if (Recurring)
                {
                    time_left = TotalTime;
                }
                else
                {
                    Stop();
                }
            }
        }
	}

    public void Play()
    {
        isPaused = false;
        if (isStopped) Restart();
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Restart()
    {
        time_left = TotalTime;
        isStopped = false;
    }

    public void Stop()
    {
        isStopped = true;
    }
}
