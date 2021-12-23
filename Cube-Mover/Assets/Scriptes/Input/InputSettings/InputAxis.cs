using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAxis : InputSettings
{
    public override Vector3 Direction()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
