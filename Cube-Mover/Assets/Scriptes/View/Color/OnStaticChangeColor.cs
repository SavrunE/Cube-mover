using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SmoothMover))]
[RequireComponent(typeof(MeshRenderer))]
public class OnStaticChangeColor : MonoBehaviour
{
    [SerializeField] private float timeToChangeColor;
    private SmoothMover smoothMover;
    private Renderer render;
    private Color defaultColor;
    private float waitingTime;
    private bool colorChanged;

    private void Start()
    {
        render = GetComponent<Renderer>();
        defaultColor = GetComponent<Renderer>().material.color;
        StartCoroutine(ColorChanger());
    }

    private void OnEnable()
    {
        smoothMover = GetComponent<SmoothMover>();
        smoothMover.OnMoving += Reset;
    }

    private void OnDisable()
    {
        smoothMover.OnMoving -= Reset;
    }

    private IEnumerator ColorChanger()
    {
        while (true)
        {
            if (waitingTime >= timeToChangeColor)
            {
                waitingTime = 0f;
                Color randomColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f), 1f);
                render.material.color = randomColor;
                colorChanged = true;
            }
            else
            {
                waitingTime += Time.deltaTime;
            }
            yield return null;
        }
    }

    private void Reset()
    {
        waitingTime = 0f;
        if (colorChanged)
        {
            render.material.color = defaultColor;
            colorChanged = false;
        }
    }
}
