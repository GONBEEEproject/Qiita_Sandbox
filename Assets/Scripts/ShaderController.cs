using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShaderController : MonoBehaviour
{
    public Color color;

    public Vector2 ice;

    public float iceTime;

    float nowIce;

    Renderer renderer;

    Sequence iceSeq;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.SetFloat("_Ice", ice.x);
        nowIce = ice.x;

        Sequence sequence = DOTween.Sequence();

        sequence.Append(DOTween.To(
            () => nowIce,
            x => nowIce = x,
            ice.y,
            iceTime).SetEase(Ease.InOutSine));

        sequence.Append(DOTween.To(
            () => nowIce,
            x => nowIce = x,
            ice.x,
            iceTime).SetEase(Ease.InOutSine));

        iceSeq = sequence;
        iceSeq.SetLoops(-1);
        iceSeq.Play();
    }

    private void Update()
    {
        renderer.material.SetFloat("_Ice", nowIce);
    }
}
