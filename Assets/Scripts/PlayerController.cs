using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour
{
    public TextMesh m_txtName;
    public float m_moveSpeed = 5.0f;
    Vector3 m_moveDir = Vector3.zero;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) Destroy(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            this.gameObject.name = "PlayerServer";
            m_txtName.text = "PlayerServer";
        }
        else
        {
            this.gameObject.name = "PlayerClient";
            m_txtName.text = "PlayerClient";
        }
        m_moveDir = new Vector3(Random.Range(-5.0f, 5.0f), 0.0f, Random.Range(-5.0f, 5.0f));
        this.transform.position = m_moveDir;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += m_moveDir * Time.deltaTime * m_moveSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter : " + other.name + " - tag : " + other.tag);
        if (other.tag == "Wall")
            m_moveDir = -m_moveDir;
    }
}
