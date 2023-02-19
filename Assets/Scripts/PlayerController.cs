using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public enum PlayerState
{
    IDLE=0,
    MOVE
}

public class PlayerController : NetworkBehaviour
{
    public float speed = 1.0f;
    //public new TextMesh nameTxt;
    public Animator playerAnimator;

    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        if (IsOwner)
            enabled = true;
        else
            enabled = false;

        //int nameNo = (int)Random.Range(10.0f, 99.0f);
        //SetName(nameNo);

        playerAnimator.SetInteger("PlayerState", (int)PlayerState.IDLE);
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsServer)
        {
            if (IsOwner)
            {
                move = Vector3.zero;
                move.x = Input.GetAxis("Horizontal");
                move.z = Input.GetAxis("Vertical");
                this.transform.position += move * speed * Time.deltaTime;
                ToggleAnimationServerRpc((int)PlayerState.MOVE);
                this.GetComponent<PlayerNetworkTransform>().UpdatePositionServerRpc(this.transform.position);
            }

            if (move == Vector3.zero)
                ToggleAnimationServerRpc((int)PlayerState.IDLE);
        }
    }

    //public void SetName(int nameNo)
    //{
    //    string playerName = "Player" + nameNo;
    //    nameTxt.text = playerName;
    //    this.gameObject.name = playerName;
    //}

    private void ToggleAnimation(int ps)
    {
        playerAnimator.SetInteger("PlayerState", ps);
    }

    [ServerRpc(RequireOwnership = false)]
    private void ToggleAnimationServerRpc(int ps)
    {
        ToggleAnimation(ps);
    }
}
