using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkObjectController : NetworkBehaviour
{
    Transform m_thisParent = null;
    bool isCheckedParent = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetNetworkObjParentServer(Transform parent)
    {
        // Debug.Log("SetNetworkObjParent : " + parent.gameObject.name);
        m_thisParent = parent;
    }

    [ClientRpc]
    public void ChangeObjectNameClientRPC(string name)
    {
        this.name = name;
    }

    private void Update()
    {
        if (isCheckedParent == false && IsServer && this.GetComponent<NetworkObject>().IsSpawned)
        {

            // Debug.Log("TrySetObjectParent Update");
            TrySetObjectParent(m_thisParent);
            isCheckedParent = true;//only try to set once
        }
    }

    void TrySetObjectParent(Transform objParent)
    {
        if (objParent != null)
        {
            bool isSetParent = this.GetComponent<NetworkObject>().TrySetParent(objParent.GetComponent<NetworkObject>());
            // if (isSetParent == false)
            //     Debug.Log("TrySetObjectParent : " + this.name + " / failed");
            // else
            //     Debug.Log("TrySetObjectParent : " + this.name + " / " + objParent.name);
        }

        /*
        string name = "null";
        if (objParent != null)
            name = this.name + "_" + objParent.name;
        // if (objParent != null && objParent.transform.parent != null && objParent.transform.parent.transform.parent != null)
        //     name = this.name + "_" + objParent.transform.parent.name + "_" + objParent.transform.parent.transform.parent.name;
        else
            name = this.name + "_" + "null";
        this.name = name;//ChangeObjectName for server
        ChangeObjectNameClientRPC(name);//ChangeObjectName for clients
        */
    }
}
