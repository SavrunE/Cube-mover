using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMover : MonoBehaviour, IMoveble
{
    [SerializeField] float speed;
    public void MoveTo(Vector3 direction, float delay)
    {
        Vector3 thisPosition = this.transform.position;
        Vector3 endPosition = thisPosition + direction * speed * delay;

        StartCoroutine(SmoothMove(thisPosition, endPosition, delay));
    }

    private IEnumerator SmoothMove(Vector3 startPosition, Vector3 endPosition, float time)
    {
        float currTime = 0;
        do
        {
            this.transform.position = Vector3.Lerp(startPosition, endPosition, currTime / time);
            currTime += Time.deltaTime;
            yield return null;
        }
        while (currTime <= time);
    }
}
