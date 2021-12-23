using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMover : MonoBehaviour, IMoveble
{
    [SerializeField] private float speed;
    [SerializeField] private Collider thisCollider;
    [SerializeField] private RefundPosition refundPosition;

    private Vector3 thisPosition;
    private Vector3 endPosition;

    public Action OnMoving;

    private void OnEnable()
    {
        refundPosition.OnRefundPosition += refundPositions;
    }

    private void OnDisable()
    {
        refundPosition.OnRefundPosition -= refundPositions;
    }

    public void MoveTo(Vector3 direction, float delay)
    {
        OnMoving?.Invoke();

        Vector3 nextPositionVector = direction * speed * delay;

        thisPosition = this.transform.position;
        endPosition = thisPosition + nextPositionVector;

        StartCoroutine(SmoothMove(delay));

        ChangeColliderPosition(nextPositionVector);
    }

    private IEnumerator SmoothMove(float time)
    {
        float currTime = 0;
        while (currTime <= time)
        {
            this.transform.position = Vector3.Lerp(thisPosition, endPosition, currTime / time);
            currTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = thisCollider.transform.position;
    }

    private void refundPositions(Vector3 refundPosition)
    {
        thisPosition -= refundPosition;
        endPosition -= refundPosition;
        ChangeSelfPosition(-refundPosition);
        ChangeColliderPosition(-refundPosition);
    }

    private void ChangeSelfPosition(Vector3 nextPosition)
    {
        this.transform.position += nextPosition;
    }

    private void ChangeColliderPosition(Vector3 nextPosition)
    {
        thisCollider.transform.position += nextPosition;
    }
}
