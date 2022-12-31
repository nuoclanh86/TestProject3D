using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour
{
    [SerializeField] GameObject packPlanes;
    [SerializeField] int widthGround = 1;
    [SerializeField] int heightGround = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < widthGround; i++)
            for (int j = 0; j < heightGround; j++)
            {
                Vector3 pos = this.transform.position;
                pos.x += 20 * (i - (int)widthGround / 2);
                pos.z += 20 * (j - (int)heightGround / 2);
                Instantiate(packPlanes, pos, Quaternion.identity, this.transform);
            }
    }
}
