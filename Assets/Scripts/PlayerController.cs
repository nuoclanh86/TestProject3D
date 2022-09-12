using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerController : NetworkBehaviour
{
    public float speed = 1.0f;
    public new TextMesh name;

    Vector3 move;
    private NetworkVariable<Vector3> nwPosition;

    private void Awake()
    {
        nwPosition = new NetworkVariable<Vector3>();
    }

    private void OnEnable()
    {
        nwPosition.OnValueChanged += OnPositionChanged;
    }

    private void OnDisable()
    {
        nwPosition.OnValueChanged -= OnPositionChanged;
    }

    // Start is called before the first frame update
    void Start()
    {
        string nametxt = "Player " + (int)Random.Range(10.0f, 99.0f);
        SetNameClientRpc(nametxt);
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

    [ClientRpc]
    public void SetNameClientRpc(string nametxt)
    {
        SetName(nametxt);
    }

    public void SetName(string nametxt)
    {
        name.text = nametxt;
        this.gameObject.name = nametxt;
    }

    [ServerRpc]
    public void UpdatePositionServerRpc(Vector3 pos)
    {
        this.transform.position = pos;
        nwPosition.Value = pos;
    }

    private void OnPositionChanged(Vector3 old, Vector3 latest)
    {
        if (!IsServer && !IsOwner)
            this.transform.position = latest;
    }
}
