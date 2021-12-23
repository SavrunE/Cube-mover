using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DelayController))]
[RequireComponent(typeof(SmoothMover))]
[RequireComponent(typeof(InputSettings))]
public class InputChecker : MonoBehaviour
{
    private DelayController delayController;
    private SmoothMover mover;
    private InputSettings inputSettings;


    private void OnEnable()
    {
        mover = GetComponent<SmoothMover>();
        delayController = GetComponent<DelayController>();
        inputSettings = GetComponent<InputSettings>();

        delayController.OnDelayTick += CheckInput;
    }

    private void OnDisable()
    {
        delayController.OnDelayTick -= CheckInput;
    }

    private void CheckInput(float delay)
    {
        Vector3 direction = inputSettings.Direction();

        if (direction != Vector3.zero)
        {
            mover.MoveTo(direction, delay);
        }
    }
}
