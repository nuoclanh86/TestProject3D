using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 1.0f;
    public new TextMesh name;

    Vector3 move;

    // Start is called before the first frame update
    void Start()
    {
        //int nameNo = (int)Random.Range(10.0f, 99.0f);
        //SetName(nameNo);
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
                move.y = Input.GetAxis("Vertical");
                this.transform.position += move * speed;
                UpdatePositionServerRpc(this.transform.position);
            }
        }
    }

    //public void SetName(int nameNo)
    //{
    //    string playerName = "Player" + nameNo;
    //    name.text = playerName;
    //    this.gameObject.name = playerName;
    //}

    [ServerRpc]
    public void UpdatePositionServerRpc(Vector3 pos)
    {
        this.transform.position = pos;
        this.GetComponent<PlayerNetworkTransform>().nwPosition.Value = pos;
    }
}
