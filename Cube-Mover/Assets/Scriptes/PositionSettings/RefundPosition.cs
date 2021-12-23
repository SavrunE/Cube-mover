using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class RefundPosition : MonoBehaviour
{
    [SerializeField] private DelayController delayController;
    [SerializeField] private float maxDistance;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = this.transform.position;
    }

    private void OnEnable()
    {
        delayController.OnDelayTick += CheckPosition;
    }
    private void OnDisable()
    {
        delayController.OnDelayTick -= CheckPosition;
    }

    private void CheckPosition(float delay)
    {
        Vector3 refundPosition = this.transform.position - startPosition;
        if ((refundPosition).magnitude > maxDistance)
        {
            this.transform.parent.transform.position -= refundPosition;
        }
    }
}
