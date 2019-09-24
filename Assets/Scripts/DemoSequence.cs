using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DemoSequence : MonoBehaviour
{
    [SerializeField]
    private Transform moveTarget;
    [SerializeField]
    private Transform startMark, endMark;

    private void Start()
    {
        moveTarget.position = startMark.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }
    }

    private void Move()
    {
        //moveTarget.DOMove(endMark.position, 2.0f);

        Sequence sequence = DOTween.Sequence();

        sequence.Append(moveTarget.DOMove(endMark.position, 2.0f));
        sequence.Append(moveTarget.DOMove(startMark.position, 2.0f));

        sequence.Play();
    }
}