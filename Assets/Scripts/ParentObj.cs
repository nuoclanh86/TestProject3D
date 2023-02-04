using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ParentObj : NetworkBehaviour
{

    public GameObject prefabTest;

    GameObject go = null;
    public static ParentObj instance;

    void Awake()
    {
        MakeSingleton();
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    public void TestSpawn()
    {
        if (IsServer)
        {
            go = Instantiate(prefabTest, Vector3.up, Quaternion.identity);
            go.GetComponent<ObstacleNetworkController>().SetNetworkObjParent(this.transform);
            go.GetComponent<NetworkObject>().Spawn(true);
        }
    }

    public void TestDestroy()
    {
        if (IsServer)
        {
            go.GetComponent<NetworkObject>().Despawn();
        }
    }

    // private void Update()
    // {
    //     if (!IsServer) return;
    //     if (go != null && go.GetComponent<NetworkObject>().IsSpawned)
    //     {
    //         Debug.Log(go.GetComponent<NetworkObject>().TrySetParent(this.gameObject.GetComponent<NetworkObject>()));
    //     }
    // }
}
