using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class UIController : MonoBehaviour
{
    public NetworkManager nwManager;

    public void StartServer()
    {
        nwManager.StartServer();
        HideButtons();
    }

    public void StartHost()
    {
        nwManager.StartHost();
        HideButtons();
    }

    public void StartClient()
    {
        nwManager.StartClient();
        HideButtons();
    }

    private void HideButtons()
    {
        this.gameObject.SetActive(false);
    }
}
