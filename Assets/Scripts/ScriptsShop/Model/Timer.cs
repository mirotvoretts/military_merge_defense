using System;
using UnityEngine;

public class Timer
{
    private float _time;

    public void Set(float responseDelay, Action actionAfterResponse)
    {
        _time += Time.deltaTime;

        if (_time >= responseDelay)
        {
            actionAfterResponse();
            ResetTime();
        }
    }

    private void ResetTime() => _time = 0f;
}