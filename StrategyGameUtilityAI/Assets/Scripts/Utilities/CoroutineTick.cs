using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTick
{
    public CoroutineTick()
    {}

    public IEnumerator Tick(Action onTick, float timeInterval)
    {
        float progress = 0;

        while (true)
        {
            progress += Time.deltaTime;

            if (progress > timeInterval)
            {
                onTick?.Invoke();
                progress = 0;
            }

            yield return null;
        }
    }
}
