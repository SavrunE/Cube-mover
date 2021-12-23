using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayController : MonoBehaviour
{
    [SerializeField] private float delayValue;
    public Action<float> OnDelayTick;

    private void Start()
    {
        StartCoroutine(Delayer(delayValue));
    }

    private IEnumerator Delayer(float delayValue)
    {
        while (true)
        {
            yield return new WaitForSeconds(delayValue);
            OnDelayTick?.Invoke(delayValue);
        }
    }
}
