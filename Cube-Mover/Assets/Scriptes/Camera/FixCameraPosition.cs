using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCameraPosition : MonoBehaviour
{
    [SerializeField] private float scale;

    private void Start()
    {
        float yPosition = scale / Camera.main.aspect * scale;
        Vector3 currentPosition = this.transform.position;
        this.transform.position = new Vector3(currentPosition.x, yPosition, currentPosition.z);
    }
}
