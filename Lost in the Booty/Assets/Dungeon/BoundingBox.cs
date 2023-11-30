using UnityEngine;

public class BoundingBoxExample : MonoBehaviour
{
    // Reference to your prefab
    public GameObject yourPrefab;

    // Instantiate the prefab
    private GameObject prefabInstance;

    void Start()
    {
        // Instantiate the prefab
        prefabInstance = Instantiate(yourPrefab, Vector3.zero, Quaternion.identity);

        // Find and print the AABB
        FindAndPrintAABB(prefabInstance);
    }

    void FindAndPrintAABB(GameObject obj)
    {
        // Get the bounds of the object
        Bounds bounds = GetPrefabBounds(obj);

        // Print the min and max points of the AABB
        Debug.Log("Min: " + bounds.min);
        Debug.Log("Max: " + bounds.max);
    }

    Bounds GetPrefabBounds(GameObject obj)
    {
        // Initialize the bounds with the first renderer's bounds
        Bounds bounds = new(Vector3.zero, Vector3.zero);

        // Iterate through all renderers in the object
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            // Expand the bounds to encapsulate the renderer's bounds
            bounds.Encapsulate(renderer.bounds);
        }

        return bounds;
    }
}
