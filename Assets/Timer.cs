using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Timer : SingletonMonoBehavior<Timer>
{
    float timeCount;
    void Update()
    {
        timeCount += Time.deltaTime;
    }

    public string GetTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(timeCount);
        return time.ToString("mm':'ss");
    }

    public static void SetCount(bool count)
    {
        instance.gameObject.SetActive(count);
    }
}
