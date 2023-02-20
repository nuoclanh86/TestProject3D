using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class testrandom : NetworkBehaviour
{
    [SerializeField] int defaultDisplayIndex = -1;
    [SerializeField] int numChildDisplay = 1;
    [SerializeField] bool deleteNonDisplayChild = false;

    List<int> m_listIndexChildObjectDisplay;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Debug.Log("testrandom OnNetworkSpawn : " + this.name);
    }

    public void InitTestRandomObj()
    {
        Debug.Log("InitTestRandomObj");
        if (!IsServer)
            return;

        if (defaultDisplayIndex >= this.transform.childCount || numChildDisplay > this.transform.childCount)
        {
            Debug.LogError("[AAF] Error : defaultDisplayIndex or numChildDisplay > childCount");
            return;
        }

        Debug.Log("[AAF] ObstacleRandom : " + this.name);

        m_listIndexChildObjectDisplay = new List<int>();

        if (defaultDisplayIndex != -1)
        {
            // DisplayIndexChild(defaultDisplayIndex);
            m_listIndexChildObjectDisplay.Add(defaultDisplayIndex);
        }
        else
        {
            // DisplayRandomIndexChild(numChildDisplay, deleteNonDisplayChild);
            RandomIndexChild(numChildDisplay);
        }

        foreach (int t in m_listIndexChildObjectDisplay)
        {
            Debug.Log("m_listIndexChildObjectDisplay: " + t);
            PrintLogServerClientRpc("m_listIndexChildObjectDisplay: " + t);
        }

        DisplayIndexChildrenServer(m_listIndexChildObjectDisplay);

        if (deleteNonDisplayChild == true)
        {
            DestroyNonDisplayChild();
            DestroyNonDisplayChildClientRpc();
        }
    }

    void DisplayIndexChildrenServer(List<int> listIndexChildObjectDisplay)
    {
        if (listIndexChildObjectDisplay.Count <= 0)
            Debug.LogError("[AAF] DisplayIndexChildren listIndexChildObjectDisplay : " + listIndexChildObjectDisplay.Count + " - " + this.name);
        int indexChildObjectDisplay = 0;
        for (int i = 0; i < this.transform.childCount; i++)
        {
            //client
            DisplayIndexChildClientRpc(i, listIndexChildObjectDisplay[indexChildObjectDisplay]);
            //server
            GameObject childObj = this.transform.GetChild(i).gameObject;
            if (i == listIndexChildObjectDisplay[indexChildObjectDisplay])
            {
                if (indexChildObjectDisplay < listIndexChildObjectDisplay.Count - 1)
                    indexChildObjectDisplay++;
                childObj.SetActive(true);
            }
            else
            {
                childObj.SetActive(false);
            }
        }
    }

    [ClientRpc]
    void PrintLogServerClientRpc(string log)
    {
        Debug.Log(log);
    }

    [ClientRpc]
    void DisplayIndexChildClientRpc(int indexChildObject, int indexChildObjectDisplay)
    {
        Debug.Log("DisplayIndexChildClientRpc : " + indexChildObject + " - " + indexChildObjectDisplay);
        GameObject childObj = this.transform.GetChild(indexChildObject).gameObject;
        if (indexChildObject == indexChildObjectDisplay)
        {
            childObj.SetActive(true);
        }
        else
        {
            childObj.SetActive(false);
        }
    }

    void DestroyNonDisplayChild()
    {
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            GameObject childObj = this.transform.GetChild(i).gameObject;
            if (childObj.activeSelf == false)
                Destroy(childObj);
        }
    }

    [ClientRpc]
    void DestroyNonDisplayChildClientRpc()
    {
        DestroyNonDisplayChild();
    }

    void RandomIndexChild(int numberChildDisplay)
    {
        // Debug.Log("[AAF] childCount : " + this.transform.childCount);
        m_listIndexChildObjectDisplay.Clear();
        for (int i = 0; i < this.transform.childCount; i++)
        {
            m_listIndexChildObjectDisplay.Add(i);
        }

        int numToRemove = m_listIndexChildObjectDisplay.Count - numberChildDisplay;
        while (numToRemove > 0)
        {
            int randomVal = Random.Range(0, m_listIndexChildObjectDisplay.Count);
            numToRemove--;
            m_listIndexChildObjectDisplay.Remove(m_listIndexChildObjectDisplay[randomVal]);
        }
    }
}
