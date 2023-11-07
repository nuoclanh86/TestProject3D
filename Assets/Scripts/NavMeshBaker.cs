using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public class NavMeshBaker : MonoBehaviour
{
    NavMeshSurface nmSurface;
    // Start is called before the first frame update
    void Start()
    {
        nmSurface = this.GetComponent<NavMeshSurface>();
    }

    // Update is called once per frame
    void Update()
    {
        if (nmSurface)
            nmSurface.BuildNavMesh();
    }
}
