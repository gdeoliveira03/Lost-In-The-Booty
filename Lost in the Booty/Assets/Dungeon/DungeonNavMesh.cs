using UnityEngine;
using UnityEngine.AI;
using DunGen;
using Unity.AI.Navigation;

public class DungeonNavMesh : MonoBehaviour
{
    public RuntimeDungeon runtimeDungeon;
    public NavMeshSurface navMeshSurface;

    void Start()
    {
        runtimeDungeon.Generator.OnGenerationStatusChanged += OnDungeonGenerationStatusChanged;
    }

    void OnDestroy()
    {
        runtimeDungeon.Generator.OnGenerationStatusChanged -= OnDungeonGenerationStatusChanged;
    }

    void OnDungeonGenerationStatusChanged(DungeonGenerator generator, GenerationStatus status)
    {
        if (status == GenerationStatus.Complete)
        {
            Debug.Log("Deneration Status is completed. Calling BuildNavMesh()");
            BuildNavMesh();
        }
    }

    void BuildNavMesh()
    {
        // Assuming your dungeon tiles have colliders
        navMeshSurface.collectObjects = (CollectObjects)NavMeshCollectGeometry.PhysicsColliders;
        navMeshSurface.layerMask = LayerMask.GetMask("Default"); // Adjust based on your layer
        navMeshSurface.BuildNavMesh();
        Debug.Log("NavMesh built");
    }
}
