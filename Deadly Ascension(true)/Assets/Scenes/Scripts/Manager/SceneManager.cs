using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI.Navigation;

public class SceneManager : MonoBehaviour
{
    [SerializeField] private NavMeshSurface surface;

    void Start()
    {
        // Appelle la méthode UpdateNavMesh toutes les 10 minutes, après un délai initial de 0 secondes.
        InvokeRepeating("UpdateNavMesh", 1f, 1000000f);
    }

    void UpdateNavMesh()
    {
        // Met à jour le NavMesh.
        surface.BuildNavMesh();
    }
}
