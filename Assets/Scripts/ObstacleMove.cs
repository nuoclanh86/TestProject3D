using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    bool isMovingup = true;
    [SerializeField] float minZPos = 1.0f;
    [SerializeField] float maxZPos = 10.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5.0f;
        if (isMovingup)
        {
            this.transform.position += Vector3.forward * Time.deltaTime * speed;
            if (this.transform.position.z > maxZPos)
                isMovingup = !isMovingup;
        }
        else
        {
            this.transform.position -= Vector3.forward * Time.deltaTime * speed;
            if (this.transform.position.z < minZPos)
                isMovingup = !isMovingup;
        }
    }
}
