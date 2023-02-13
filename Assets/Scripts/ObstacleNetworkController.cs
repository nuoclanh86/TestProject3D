using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ObstacleNetworkController : NetworkBehaviour
{
    Transform m_thisParent = null;
    bool isCheckedParent = false;

    // Start is called before the first frame update
    void Start()
    {
        // m_thisParent = this.transform.parent;
    }

    public void SetNetworkObjParent(Transform parent)
    {
        Debug.Log("SetNetworkObjParent : " + parent.gameObject.name);
        m_thisParent = parent;
        // if (m_thisParent != null)
        //     Debug.Log("SetNetworkObjParent : m_thisParent != null");
    }

    [ClientRpc]
    public void ChangeObjectNameClientRPC(string name)
    {
        this.name = name;
    }

    private void Update()
    {
        if (!IsServer) return;
        if (isCheckedParent == false && this.GetComponent<NetworkObject>().IsSpawned)
        {
            if (m_thisParent != null)
            {
                bool isSetParent = this.GetComponent<NetworkObject>().TrySetParent(m_thisParent.gameObject.GetComponent<NetworkObject>());
                if (isSetParent == true)
                    Debug.Log("ObstacleNetworkController : " + this.name + " / " + m_thisParent.name);
                else
                    Debug.Log("ObstacleNetworkController : " + this.name + " / failed");
            }
            // else
            // {
            //     Debug.Log("TrySetParent : " + this.name + " failed . Parent == null");
            // }

            string name = "null";
            if (m_thisParent != null)
                name = this.name + "_" + m_thisParent.name;
            else
                name = this.name + "_" + "null";
            this.name = name;//ChangeObjectName for server
            ChangeObjectNameClientRPC(name);//ChangeObjectName for clients
            isCheckedParent = true;//only try to set once
        }
    }
}
