using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 moveDir = Vector3.zero;
    [SerializeField] float speedMove = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        moveDir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");

        if (moveDir != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, this.transform.position + moveDir, Time.deltaTime * speedMove);
        }
    }
}
