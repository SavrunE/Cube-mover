using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMover : MonoBehaviour, IMoveble
{
    [SerializeField] float speed;
    [SerializeField] Collider thisCollider;

    public Action OnMoving;

    public void MoveTo(Vector3 direction, float delay)
    {
        OnMoving?.Invoke();

        Vector3 thisPosition = this.transform.position;
        Vector3 endPosition = thisPosition + direction * speed * delay;

        StartCoroutine(SmoothMove(thisPosition, endPosition, delay));

        thisCollider.transform.position = thisCollider.transform.position + direction * speed * delay;
    }

    private IEnumerator SmoothMove(Vector3 startPosition, Vector3 endPosition, float time)
    {
        float currTime = 0;
        while (currTime <= time)
        {
            this.transform.position = Vector3.Lerp(startPosition, endPosition, currTime / time);
            currTime += Time.deltaTime;
            yield return null;
        }
        this.transform.position = thisCollider.transform.position;
    }
}
