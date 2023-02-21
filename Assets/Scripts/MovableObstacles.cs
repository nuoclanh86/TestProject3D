using UnityEngine;
using DG.Tweening;
using System;

public class MovableObstacles : MonoBehaviour
{
    protected Sequence mySequence;

    protected Action<Collider> onTriggerEnterCb;
    // protected Bounce[] mBounce;
    protected Vector3 defaultPos;

    protected virtual void Start()
    {
        defaultPos = transform.position;
        // if (!GameManager.Instance.mIsMulti)
        // {
        //     DoMove();
        // }
    }

    public virtual void ReStart()
    {
        transform.position = defaultPos;
        gameObject.SetActive(true);
        DoMove();
    }

    public void RegistryCallBack(Action<Collider> callback)
    {
        onTriggerEnterCb = callback;
    }

    public void StopMovement()
    {
        // mySequence.Pause();
        mySequence.Kill();
    }

    public virtual void DoMove()
    {
        Debug.LogError("[AAF] MovableObstacles : this function should not be called !");
        if (!enabled)
        {
            return;
        }
    }

    // protected virtual void OnTriggerEnter(Collider other)
    // {
    //     if (gameObject == null || !gameObject.activeSelf)
    //     {
    //         return;
    //     }

    //     if (other.tag == TAG.PLAYER || other.tag == TAG.BOT)
    //     {
    //         if (onTriggerEnterCb != null)
    //         {
    //             onTriggerEnterCb.Invoke(other);
    //         }
    //     }
    // }
}
