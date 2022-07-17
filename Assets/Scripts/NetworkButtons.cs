using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class NetworkButtons : MonoBehaviour
{
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10, 10, 300, 300));
        if (!NetworkManager.Singleton.IsClient && !NetworkManager.Singleton.IsServer)
        {
            if (GUILayout.Button("Host", GUILayout.Height(50))) NetworkManager.Singleton.StartHost();
            if (GUILayout.Button("Server", GUILayout.Height(50))) NetworkManager.Singleton.StartServer();
            if (GUILayout.Button("Client", GUILayout.Height(50))) NetworkManager.Singleton.StartClient();
        }
        GUILayout.EndArea();
    }
}