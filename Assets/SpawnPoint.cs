using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpawnPoint : NetworkBehaviour
{
    [SerializeField] GameObject itemPrefab;

    public void SpawnItem()
    {
        if (IsServer)
            SpawnServer();
    }

    void SpawnServer()
    {
        if (itemPrefab != null)
        {
            GameObject result = null;
            result = Instantiate(itemPrefab, this.transform.position, Quaternion.identity);
            result.GetComponent<NetworkObjectController>().SetNetworkObjParentServer(this.transform);
            result.GetComponent<NetworkObject>().Spawn(true);
        }
    }
}
