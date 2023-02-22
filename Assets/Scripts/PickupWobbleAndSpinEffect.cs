using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PickupWobbleAndSpinEffect : MovableObstacles
{
    [SerializeField]
    protected bool allowFloat = true;
    [SerializeField]
    protected bool allowSpin = true;

    [SerializeField]
    protected float distance = 0.4f;

    [SerializeField]
    protected float firstOutHalfDuration = 1.5f;
    [SerializeField]
    protected float firstInHalfDuration = 1.5f;

    [SerializeField]
    protected Ease firstEaseType = Ease.Linear;
    [SerializeField]
    protected Ease secondEaseType = Ease.Linear;

    protected Vector3 targetPos;
    protected Ease curFirstEaseType;
    protected Ease curSecondEaseType;

    Vector3 direction, rotDirection1, rotDirection2;

    protected override void Start()
    {
        if (allowFloat)
        {
            if (Random.value <= 0.5f)
            {
                direction = Vector3.up;
                transform.localPosition += Vector3.down * (distance / 2);
            }
            else
            {
                direction = Vector3.down;
                transform.localPosition += Vector3.up * (distance / 2);
            }
        }
        else direction = Vector3.zero;

        if (allowSpin)
        {
            if (Random.value <= 0.5f)
            {
                rotDirection1 = new Vector3(0, 180f, 0);
                rotDirection2 = new Vector3(0, 360f, 0);
            }
            else
            {
                rotDirection1 = new Vector3(0, -180f, 0);
                rotDirection2 = Vector3.zero;
            }
        }
        else rotDirection1 = rotDirection2 = Vector3.zero;

        // defaultPos = transform.position;
        defaultPos = transform.localPosition;
        // if (!GameManager.Instance.mIsMulti)
        {
            DoMove();
        }

    }

    public override void ReStart()
    {
        transform.localPosition = defaultPos;
        gameObject.SetActive(true);
        DoMove();
    }

    public override void DoMove()
    {
        if (!enabled || (!allowFloat && !allowSpin))
        {
            return;
        }

        targetPos = direction * distance;

        mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOLocalRotate(transform.localRotation.eulerAngles + rotDirection1, firstInHalfDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear));
        mySequence.Join(transform.DOLocalRotate(transform.localRotation.eulerAngles + rotDirection2, firstOutHalfDuration, RotateMode.FastBeyond360).SetEase(Ease.Linear));

        mySequence.SetLoops(-1);
        // if (GameManager.Instance.mIsMulti)
        // {
        //     mySequence.SetUpdate(UpdateType.Manual);
        // }
    }

    void OnDestroy()
    {
        mySequence.Kill();
    }
}
