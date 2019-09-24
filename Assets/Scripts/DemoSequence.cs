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

    private Sequence sequence;

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

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Stop();
        }
    }

    private void Move()
    {
        Sequence tmpSeq = DOTween.Sequence();   //メソッド内で個別に宣言しないといけない

        tmpSeq.Append(moveTarget.DOMove(endMark.position, 2.0f));
        tmpSeq.Append(moveTarget.DOMove(startMark.position, 2.0f));

        sequence = tmpSeq;                      //ローカル宣言のSequenceをクラス変数に入れ直す

        sequence.Play();                        //クラス変数のSequence（中身入り）を再生する
    }

    private void Stop()
    {
        sequence.Kill();
    }
}