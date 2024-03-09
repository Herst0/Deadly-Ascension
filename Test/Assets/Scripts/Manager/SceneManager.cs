using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;
    void Update()
    {
        surface.BuildNavMesh();
    }
}
