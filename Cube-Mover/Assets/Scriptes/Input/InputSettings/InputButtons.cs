using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputButtons : InputSettings
{
    [SerializeField] private UIButtonInfo buttonUp;
    [SerializeField] private UIButtonInfo buttonDown;
    [SerializeField] private UIButtonInfo buttonLeft;
    [SerializeField] private UIButtonInfo buttonRight;
    public override Vector3 Direction()
    {
        float horizontalDirection = DirectionOppositeButtons(buttonRight, buttonLeft);
        float verticalDirection = DirectionOppositeButtons(buttonUp, buttonDown);
        return new Vector3(horizontalDirection, 0f, verticalDirection);
    }

    private float DirectionOppositeButtons(UIButtonInfo one, UIButtonInfo two)
    {
        float endValue = 0f;
        if (one.isDown)
        {
            endValue += 1f;
        }
        if (two.isDown)
        {
            endValue -= 1f;
        }
        return endValue;
    }
}
