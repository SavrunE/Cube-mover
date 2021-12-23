using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMoveble
{
    public void MoveTo(Vector3 direction, float delay);
}
