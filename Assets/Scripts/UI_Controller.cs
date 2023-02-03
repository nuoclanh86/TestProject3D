using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class UI_Controller : MonoBehaviour
{
    public NetworkManager nwManager;
    [SerializeField] GameObject btnMainMenu, btnIngame;

    public void StartServer()
    {
        nwManager.StartServer();
        HideButtonsMainMenu();
    }

    public void StartHost()
    {
        nwManager.StartHost();
        HideButtonsMainMenu();
    }

    public void StartClient()
    {
        nwManager.StartClient();
        HideButtonsMainMenu();
    }

    private void HideButtonsMainMenu()
    {
        btnMainMenu.gameObject.SetActive(false);
        if (nwManager.IsServer || nwManager.IsHost)
            btnIngame.gameObject.SetActive(true);
    }
}
