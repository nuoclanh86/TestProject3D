using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetworkTransform : NetworkBehaviour
{
    public NetworkVariable<Vector3> nwPosition;

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

    private void OnPositionChanged(Vector3 old, Vector3 latest)
    {
        if (!IsServer && !IsOwner)
            this.transform.position = latest;
    }
}
