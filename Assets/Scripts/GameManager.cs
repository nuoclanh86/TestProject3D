using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class GameManager : MonoBehaviour
{
    public Text m_TextDebug;
    string logDebug = "logDebug";

    public static GameManager Instance;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        logDebug = NetworkManager.Singleton.IsServer ? "Player : Server\n" : "Player : Client\n";
        m_TextDebug.text = logDebug;
    }
}
