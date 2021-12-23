using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputSettings : MonoBehaviour, IInputer
{
    public abstract Vector3 Direction();
}
